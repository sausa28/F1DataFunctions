CREATE TABLE [staging].[driverStandings] (
    [driverStandingsId] INT           NOT NULL,
    [raceId]            INT           NOT NULL,
    [driverId]          INT           NOT NULL,
    [points]            FLOAT (53)    NOT NULL,
    [position]          INT           NULL,
    [positionText]      VARCHAR (255) NULL,
    [wins]              INT           NOT NULL
);

