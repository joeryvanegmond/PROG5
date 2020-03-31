CREATE TABLE [dbo].[Workshop]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(64) NULL, 
    [Summary] NVARCHAR(MAX) NOT NULL, 
    [TeacherId] INT NULL,
	CONSTRAINT FK_Workshop_Teacher FOREIGN KEY (TeacherId) REFERENCES dbo.Teacher ([Id]),
)
