using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Testcontainers.MsSql;
using Xunit;

namespace F1DataFunctions.Tests;

public class F1DatabaseFixture : IAsyncLifetime
{
    private MsSqlContainer _msSqlContainer;
    
    public string ConnectionString { get; private set; }
    
    public async Task InitializeAsync()
    {
        // Need to run this first: systemctl --user start podman.socket
        Environment.SetEnvironmentVariable("DOCKER_HOST", "unix:///run/user/1000/podman/podman.sock");
        Environment.SetEnvironmentVariable("TESTCONTAINERS_RYUK_DISABLED", "true");
        _msSqlContainer = new MsSqlBuilder()
            .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
            .Build();
        await _msSqlContainer.StartAsync();
        CreateEmptyDatabase();
        var sqlConnection = new SqlConnectionStringBuilder(_msSqlContainer.GetConnectionString())
        {
            InitialCatalog = "formula1db"
        };
        ConnectionString = sqlConnection.ConnectionString;
    }

    private void CreateEmptyDatabase()
    {
        using var connection = new SqlConnection(_msSqlContainer.GetConnectionString());
        
        connection.Open();
        var command = new SqlCommand("DROP DATABASE IF EXISTS formula1db; CREATE DATABASE formula1db", connection);
        command.ExecuteNonQuery();
        connection.ChangeDatabase("formula1db");
        command = new SqlCommand("CREATE SCHEMA staging;", connection);
        command.ExecuteNonQuery();
        var sqlFiles = Directory.GetFileSystemEntries("/home/sausa/repos/F1DataFunctions/formula1db", "*.sql", SearchOption.AllDirectories);
        foreach (var sqlFile in sqlFiles.OrderDescending()) // Order so that the races table gets created before the 2 tables that depend on it
        {
            if (sqlFile.Contains("staging.sql"))
                continue;
            command = new SqlCommand(File.ReadAllText(sqlFile), connection);
            command.ExecuteNonQuery();
        }
    }
    
    public async Task DisposeAsync()
    {
        await _msSqlContainer.DisposeAsync();
    }
}