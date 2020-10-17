CREATE TABLE [dbo].[lapTimes] (
    [raceId]       INT           NOT NULL,
    [driverId]     INT           NOT NULL,
    [lap]          INT           NOT NULL,
    [position]     INT           DEFAULT (NULL) NULL,
    [time]         VARCHAR (255) DEFAULT (NULL) NULL,
    [milliseconds] INT           DEFAULT (NULL) NULL,
    CONSTRAINT [pk_lapTimes] PRIMARY KEY CLUSTERED ([raceId] ASC, [driverId] ASC, [lap] ASC),
    CONSTRAINT [fk_lapTimes_races] FOREIGN KEY ([raceId]) REFERENCES [dbo].[races] ([raceId])
);

