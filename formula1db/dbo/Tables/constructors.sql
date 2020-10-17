CREATE TABLE [dbo].[constructors] (
    [constructorId]  INT           NOT NULL,
    [constructorRef] VARCHAR (255) DEFAULT ('') NOT NULL,
    [name]           VARCHAR (255) DEFAULT ('') NOT NULL,
    [nationality]    VARCHAR (255) DEFAULT (NULL) NULL,
    [url]            VARCHAR (255) DEFAULT ('') NOT NULL,
    CONSTRAINT [pk_constructors] PRIMARY KEY CLUSTERED ([constructorId] ASC),
    CONSTRAINT [uq_constructors_name] UNIQUE NONCLUSTERED ([name] ASC)
);

