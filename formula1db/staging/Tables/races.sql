CREATE TABLE [staging].[races] (
    [raceId]    INT           NOT NULL,
    [year]      INT           NOT NULL,
    [round]     INT           NOT NULL,
    [circuitId] INT           NOT NULL,
    [name]      VARCHAR (255) NOT NULL,
    [date]      DATE          NOT NULL,
    [time]      TIME (7)      NULL,
    [url]       VARCHAR (255) NULL
);

