MERGE INTO Workshop AS Target  
USING (values 
	(1, 'PROG5', 'Leren programmeren in C#', 1),
	(2, 'PROG4', 'Leren programmeren in Java', 2),
	(3, 'WEBS1', 'Leren programmeren in HTML & CSS', 3)
) AS Source (Id, Name, Summary, TeacherId)  
ON Target.Id = Source.Id  
WHEN NOT MATCHED BY TARGET THEN  
	INSERT (Id, Name, Summary, TeacherId)  
	VALUES (Id, Name, Summary, TeacherId)  
WHEN MATCHED THEN
	UPDATE SET
		Name = Source.Name,
		Summary = Source.Summary,
		TeacherId = Source.TeacherId;
