CREATE TABLE [dbo].[constructorResults] (
    [constructorResultsId] INT           NOT NULL,
    [raceId]               INT           DEFAULT ('0') NOT NULL,
    [constructorId]        INT           DEFAULT ('0') NOT NULL,
    [points]               FLOAT (53)    DEFAULT (NULL) NULL,
    [status]               VARCHAR (255) DEFAULT (NULL) NULL,
    CONSTRAINT [pk_constructorResults] PRIMARY KEY CLUSTERED ([constructorResultsId] ASC)
);

