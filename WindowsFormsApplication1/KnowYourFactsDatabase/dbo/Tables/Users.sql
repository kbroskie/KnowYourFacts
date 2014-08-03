CREATE TABLE [dbo].[Users] (
    [Username] NCHAR (10)     NOT NULL,
    [Salt]     VARBINARY (50) NULL,
    [Key]      VARBINARY (50) NULL,
    PRIMARY KEY CLUSTERED ([Username] ASC)
);

