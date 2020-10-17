using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace F1DataFunctions
{
    internal class CsvReader
    {
        public async Task<DataTable> LoadCsvToDataTableAsync(string csvFile)
        {
            using var csvReader = new StreamReader(csvFile);

            string[] headers = (await csvReader.ReadLineAsync()).Split(',');
            var dataTable = new DataTable();

            foreach (string header in headers)
            {
                dataTable.Columns.Add(header);
            }

            string rowText;
            while ((rowText = await csvReader.ReadLineAsync()) != null)
            {
                DataRow row = dataTable.NewRow();

                bool isInQuote = false;
                var fieldBuilder = new StringBuilder();
                var fieldValues = new List<string>();
                foreach(char c in rowText)
                {
                    if (c == '"')
                    {
                        isInQuote = !isInQuote;
                    }
                    else if (!isInQuote && c == ',')
                    {
                        fieldValues.Add(fieldBuilder.ToString());
                        fieldBuilder = new StringBuilder();
                    }
                    else
                    {
                        fieldBuilder.Append(c);
                    }
                }
                fieldValues.Add(fieldBuilder.ToString());

                for (int i = 0; i < fieldValues.Count; i++)
                {
                    string field = fieldValues[i];
                    if (field == @"\N")
                        row[i] = DBNull.Value;
                    else
                        row[i] = field.Trim('"');
                }

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}
