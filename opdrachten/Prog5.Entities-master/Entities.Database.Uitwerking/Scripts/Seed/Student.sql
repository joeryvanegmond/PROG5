MERGE INTO dbo.Student AS Target  
USING (values 
	(1, 'Mik Rijer' ),
	(2, 'Ser Garis'),
	(3, 'Sartijn Muurmans')
) AS Source (Id, Name)  
ON Target.Id = Source.Id  
WHEN NOT MATCHED BY TARGET THEN  
	INSERT (Id, Name)  
	VALUES (Id, Name)  
WHEN MATCHED THEN
	UPDATE SET
		Name = Source.Name;