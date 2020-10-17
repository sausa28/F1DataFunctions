CREATE TABLE [staging].[lapTimes] (
    [raceId]       INT           NOT NULL,
    [driverId]     INT           NOT NULL,
    [lap]          INT           NOT NULL,
    [position]     INT           NULL,
    [time]         VARCHAR (255) NULL,
    [milliseconds] INT           NULL
);

