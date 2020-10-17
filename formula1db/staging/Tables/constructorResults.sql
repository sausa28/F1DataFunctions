CREATE TABLE [staging].[constructorResults] (
    [constructorResultsId] INT           NOT NULL,
    [raceId]               INT           NOT NULL,
    [constructorId]        INT           NOT NULL,
    [points]               FLOAT (53)    NULL,
    [status]               VARCHAR (255) NULL
);

