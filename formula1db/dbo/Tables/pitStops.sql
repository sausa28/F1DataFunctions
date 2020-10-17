CREATE TABLE [dbo].[pitStops] (
    [raceId]       INT           NOT NULL,
    [driverId]     INT           NOT NULL,
    [stop]         INT           NOT NULL,
    [lap]          INT           NOT NULL,
    [time]         TIME (7)      NOT NULL,
    [duration]     VARCHAR (255) DEFAULT (NULL) NULL,
    [milliseconds] INT           DEFAULT (NULL) NULL,
    CONSTRAINT [pk_pitStops] PRIMARY KEY CLUSTERED ([raceId] ASC, [driverId] ASC, [stop] ASC),
    CONSTRAINT [fk_pitStops_races] FOREIGN KEY ([raceId]) REFERENCES [dbo].[races] ([raceId])
);

