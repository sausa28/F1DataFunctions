CREATE TABLE [dbo].[qualifying] (
    [qualifyId]     INT           NOT NULL,
    [raceId]        INT           DEFAULT ('0') NOT NULL,
    [driverId]      INT           DEFAULT ('0') NOT NULL,
    [constructorId] INT           DEFAULT ('0') NOT NULL,
    [number]        INT           DEFAULT ('0') NOT NULL,
    [position]      INT           DEFAULT (NULL) NULL,
    [q1]            VARCHAR (255) DEFAULT (NULL) NULL,
    [q2]            VARCHAR (255) DEFAULT (NULL) NULL,
    [q3]            VARCHAR (255) DEFAULT (NULL) NULL,
    CONSTRAINT [pk_qualifying] PRIMARY KEY CLUSTERED ([qualifyId] ASC)
);

