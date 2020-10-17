CREATE TABLE [dbo].[seasons] (
    [year] INT           DEFAULT ('0') NOT NULL,
    [url]  VARCHAR (255) DEFAULT ('') NOT NULL,
    CONSTRAINT [pk_seasons] PRIMARY KEY CLUSTERED ([year] ASC),
    CONSTRAINT [uq_seasons_url] UNIQUE NONCLUSTERED ([url] ASC)
);

