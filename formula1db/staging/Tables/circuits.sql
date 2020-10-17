CREATE TABLE [staging].[circuits] (
    [circuitId]  INT           NOT NULL,
    [circuitRef] VARCHAR (255) NOT NULL,
    [name]       VARCHAR (255) NOT NULL,
    [location]   VARCHAR (255) NULL,
    [country]    VARCHAR (255) NULL,
    [lat]        FLOAT (53)    NULL,
    [lng]        FLOAT (53)    NULL,
    [alt]        INT           NULL,
    [url]        VARCHAR (255) NOT NULL
);

