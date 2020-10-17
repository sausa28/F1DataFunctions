CREATE TABLE [dbo].[drivers] (
    [driverId]    INT           NOT NULL,
    [driverRef]   VARCHAR (255) DEFAULT ('') NOT NULL,
    [number]      INT           DEFAULT (NULL) NULL,
    [code]        VARCHAR (3)   DEFAULT (NULL) NULL,
    [forename]    VARCHAR (255) DEFAULT ('') NOT NULL,
    [surname]     VARCHAR (255) DEFAULT ('') NOT NULL,
    [dob]         DATE          DEFAULT (NULL) NULL,
    [nationality] VARCHAR (255) DEFAULT (NULL) NULL,
    [url]         VARCHAR (255) DEFAULT ('') NOT NULL,
    CONSTRAINT [pk_drivers] PRIMARY KEY CLUSTERED ([driverId] ASC),
    CONSTRAINT [uq_drivers_url] UNIQUE NONCLUSTERED ([url] ASC)
);

