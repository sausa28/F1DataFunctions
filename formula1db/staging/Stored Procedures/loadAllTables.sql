CREATE   PROCEDURE staging.loadAllTables
AS
BEGIN
SET NOCOUNT, XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION;

	ALTER TABLE [dbo].[lapTimes] DROP CONSTRAINT [fk_lapTimes_races];
	ALTER TABLE [dbo].[pitStops] DROP CONSTRAINT [fk_pitStops_races];

	TRUNCATE TABLE dbo.races;
	TRUNCATE TABLE dbo.circuits;
	TRUNCATE TABLE dbo.constructorResults;
	TRUNCATE TABLE dbo.constructors;
	TRUNCATE TABLE dbo.constructorStandings;
	TRUNCATE TABLE dbo.drivers;
	TRUNCATE TABLE dbo.driverStandings;
	TRUNCATE TABLE dbo.lapTimes;
	TRUNCATE TABLE dbo.pitStops;
	TRUNCATE TABLE dbo.qualifying;
	TRUNCATE TABLE dbo.results;
	TRUNCATE TABLE dbo.seasons;
	TRUNCATE TABLE dbo.status;

	INSERT INTO dbo.races SELECT * FROM staging.races;
	INSERT INTO dbo.circuits SELECT * FROM staging.circuits;
	INSERT INTO dbo.constructorResults SELECT * FROM staging.constructorResults;
	INSERT INTO dbo.constructors SELECT * FROM staging.constructors;
	INSERT INTO dbo.constructorStandings SELECT * FROM staging.constructorStandings;
	INSERT INTO dbo.drivers SELECT * FROM staging.drivers;
	INSERT INTO dbo.driverStandings SELECT * FROM staging.driverStandings;
	INSERT INTO dbo.lapTimes SELECT * FROM staging.lapTimes;
	INSERT INTO dbo.pitStops SELECT * FROM staging.pitStops;
	INSERT INTO dbo.qualifying SELECT * FROM staging.qualifying;
	INSERT INTO dbo.results SELECT * FROM staging.results;
	INSERT INTO dbo.seasons SELECT * FROM staging.seasons;
	INSERT INTO dbo.status SELECT * FROM staging.status;	
	
	ALTER TABLE [dbo].[lapTimes]  WITH CHECK ADD  CONSTRAINT [fk_lapTimes_races] FOREIGN KEY([raceId])
		REFERENCES [dbo].[races] ([raceId]);
	ALTER TABLE [dbo].[pitStops]  WITH CHECK ADD  CONSTRAINT [fk_pitStops_races] FOREIGN KEY([raceId])
		REFERENCES [dbo].[races] ([raceId]);

	ALTER TABLE [dbo].[lapTimes] CHECK CONSTRAINT [fk_lapTimes_races];
	ALTER TABLE [dbo].[pitStops] CHECK CONSTRAINT [fk_pitStops_races];

	COMMIT TRANSACTION;
END TRY
BEGIN CATCH
	IF XACT_STATE() <> 0
		ROLLBACK;

	THROW;
END CATCH
END