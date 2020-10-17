CREATE TABLE [dbo].[driverStandings] (
    [driverStandingsId] INT           NOT NULL,
    [raceId]            INT           DEFAULT ('0') NOT NULL,
    [driverId]          INT           DEFAULT ('0') NOT NULL,
    [points]            FLOAT (53)    DEFAULT ('0') NOT NULL,
    [position]          INT           DEFAULT (NULL) NULL,
    [positionText]      VARCHAR (255) DEFAULT (NULL) NULL,
    [wins]              INT           DEFAULT ('0') NOT NULL,
    CONSTRAINT [pk_driverStandings] PRIMARY KEY CLUSTERED ([driverStandingsId] ASC)
);

