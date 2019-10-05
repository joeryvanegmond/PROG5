MERGE INTO dbo.StudentWorkshop AS Target  
USING (values 
	(1, 1),
	(2, 2),
	(3, 3)
) AS Source (StudentId, WorkshopId)  
ON Target.StudentId = Source.StudentId  
and Target.WorkshopId = Source.WorkshopId
WHEN NOT MATCHED BY TARGET THEN  
	INSERT (StudentId, WorkshopId)  
	VALUES (StudentId, WorkshopId);
