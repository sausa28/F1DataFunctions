CREATE TABLE [staging].[pitStops] (
    [raceId]       INT           NOT NULL,
    [driverId]     INT           NOT NULL,
    [stop]         INT           NOT NULL,
    [lap]          INT           NOT NULL,
    [time]         TIME (7)      NOT NULL,
    [duration]     VARCHAR (255) NULL,
    [milliseconds] INT           NULL
);

