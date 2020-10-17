CREATE TABLE [dbo].[results] (
    [resultId]        INT           NOT NULL,
    [raceId]          INT           DEFAULT ('0') NOT NULL,
    [driverId]        INT           DEFAULT ('0') NOT NULL,
    [constructorId]   INT           DEFAULT ('0') NOT NULL,
    [number]          INT           DEFAULT (NULL) NULL,
    [grid]            INT           DEFAULT ('0') NOT NULL,
    [position]        INT           DEFAULT (NULL) NULL,
    [positionText]    VARCHAR (255) DEFAULT ('') NOT NULL,
    [positionOrder]   INT           DEFAULT ('0') NOT NULL,
    [points]          FLOAT (53)    DEFAULT ('0') NOT NULL,
    [laps]            INT           DEFAULT ('0') NOT NULL,
    [time]            VARCHAR (255) DEFAULT (NULL) NULL,
    [milliseconds]    INT           DEFAULT (NULL) NULL,
    [fastestLap]      INT           DEFAULT (NULL) NULL,
    [rank]            INT           DEFAULT ('0') NULL,
    [fastestLapTime]  VARCHAR (255) DEFAULT (NULL) NULL,
    [fastestLapSpeed] VARCHAR (255) DEFAULT (NULL) NULL,
    [statusId]        INT           DEFAULT ('0') NOT NULL,
    CONSTRAINT [pk_results] PRIMARY KEY CLUSTERED ([resultId] ASC)
);

