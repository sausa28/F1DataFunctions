CREATE TABLE [dbo].[races] (
    [raceId]    INT           NOT NULL,
    [year]      INT           DEFAULT ('0') NOT NULL,
    [round]     INT           DEFAULT ('0') NOT NULL,
    [circuitId] INT           DEFAULT ('0') NOT NULL,
    [name]      VARCHAR (255) DEFAULT ('') NOT NULL,
    [date]      DATE          DEFAULT ('0000-00-00') NOT NULL,
    [time]      TIME (7)      DEFAULT (NULL) NULL,
    [url]       VARCHAR (255) DEFAULT (NULL) NULL,
    CONSTRAINT [pk_races] PRIMARY KEY CLUSTERED ([raceId] ASC),
    CONSTRAINT [uq_races_url] UNIQUE NONCLUSTERED ([url] ASC)
);

