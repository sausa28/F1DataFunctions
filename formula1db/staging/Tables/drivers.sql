CREATE TABLE [staging].[drivers] (
    [driverId]    INT           NOT NULL,
    [driverRef]   VARCHAR (255) NOT NULL,
    [number]      INT           NULL,
    [code]        VARCHAR (3)   NULL,
    [forename]    VARCHAR (255) NOT NULL,
    [surname]     VARCHAR (255) NOT NULL,
    [dob]         DATE          NULL,
    [nationality] VARCHAR (255) NULL,
    [url]         VARCHAR (255) NOT NULL
);

