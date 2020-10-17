CREATE TABLE [staging].[results] (
    [resultId]        INT           NOT NULL,
    [raceId]          INT           NOT NULL,
    [driverId]        INT           NOT NULL,
    [constructorId]   INT           NOT NULL,
    [number]          INT           NULL,
    [grid]            INT           NOT NULL,
    [position]        INT           NULL,
    [positionText]    VARCHAR (255) NOT NULL,
    [positionOrder]   INT           NOT NULL,
    [points]          FLOAT (53)    NOT NULL,
    [laps]            INT           NOT NULL,
    [time]            VARCHAR (255) NULL,
    [milliseconds]    INT           NULL,
    [fastestLap]      INT           NULL,
    [rank]            INT           NULL,
    [fastestLapTime]  VARCHAR (255) NULL,
    [fastestLapSpeed] VARCHAR (255) NULL,
    [statusId]        INT           NOT NULL
);

