CREATE TABLE [dbo].[circuits] (
    [circuitId]  INT           NOT NULL,
    [circuitRef] VARCHAR (255) DEFAULT ('') NOT NULL,
    [name]       VARCHAR (255) DEFAULT ('') NOT NULL,
    [location]   VARCHAR (255) DEFAULT (NULL) NULL,
    [country]    VARCHAR (255) DEFAULT (NULL) NULL,
    [lat]        FLOAT (53)    DEFAULT (NULL) NULL,
    [lng]        FLOAT (53)    DEFAULT (NULL) NULL,
    [alt]        INT           DEFAULT (NULL) NULL,
    [url]        VARCHAR (255) DEFAULT ('') NOT NULL,
    CONSTRAINT [pk_circuit] PRIMARY KEY CLUSTERED ([circuitId] ASC),
    CONSTRAINT [uq_circuit_url] UNIQUE NONCLUSTERED ([url] ASC)
);

