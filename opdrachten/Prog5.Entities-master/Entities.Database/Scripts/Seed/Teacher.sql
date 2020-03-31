MERGE INTO dbo.Teacher AS Target  
USING (values 
	(1, 'Stijn Smulders', 'Subway eten, code tokken en league of legends'),
	(2, 'Ger Saris', 'Java, uitleggen en introducties'),
	(3, 'Paul Wagener', 'security, web en eigenlijk alles wel')
) AS Source (Id, Name, Skills)  
ON Target.Id = Source.Id  
WHEN NOT MATCHED BY TARGET THEN  
	INSERT (Id, Name, Skills)  
	VALUES (Id, Name, Skills)  
WHEN MATCHED THEN
	UPDATE SET
		Name = Source.Name,
		Skills = Source.Skills;
