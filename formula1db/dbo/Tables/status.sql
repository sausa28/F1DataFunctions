CREATE TABLE [dbo].[status] (
    [statusId] INT           NOT NULL,
    [status]   VARCHAR (255) DEFAULT ('') NOT NULL,
    CONSTRAINT [pk_status] PRIMARY KEY CLUSTERED ([statusId] ASC)
);

