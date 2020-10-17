CREATE TABLE [staging].[qualifying] (
    [qualifyId]     INT           NOT NULL,
    [raceId]        INT           NOT NULL,
    [driverId]      INT           NOT NULL,
    [constructorId] INT           NOT NULL,
    [number]        INT           NOT NULL,
    [position]      INT           NULL,
    [q1]            VARCHAR (255) NULL,
    [q2]            VARCHAR (255) NULL,
    [q3]            VARCHAR (255) NULL
);

