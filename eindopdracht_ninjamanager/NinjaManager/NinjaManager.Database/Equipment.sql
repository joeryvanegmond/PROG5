CREATE TABLE [dbo].[Equipment]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(50) NOT NULL, 
	Category VARCHAR(50) NOT NULL, 
    [Gold] INT NOT NULL, 
    [Strength] INT NOT NULL, 
    [Agility] INT NOT NULL, 
    [Intelligence] INT NOT NULL
	CONSTRAINT [FK_Equipment_ToCategory] FOREIGN KEY (Category) REFERENCES Category(Category),
)
