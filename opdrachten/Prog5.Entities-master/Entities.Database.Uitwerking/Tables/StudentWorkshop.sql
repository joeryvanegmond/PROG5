CREATE TABLE [dbo].[StudentWorkshop]
(
	[StudentId] INT NOT NULL ,
	[WorkshopId] INT NOT NULL,
    PRIMARY KEY ([StudentId], [WorkshopId]),
	CONSTRAINT FK_CompetitionTeam_Team FOREIGN KEY ([StudentId]) REFERENCES dbo.Student ([Id]),
	CONSTRAINT FK_CompetitionTeam_Competition FOREIGN KEY ([WorkshopId]) REFERENCES dbo.Workshop ([Id])
)
