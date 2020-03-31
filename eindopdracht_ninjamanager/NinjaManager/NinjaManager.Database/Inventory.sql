CREATE TABLE [dbo].[Inventory]
(
	[NinjaId] INT NOT NULL, 
    [EquipmentId] INT NOT NULL
	primary key (NinjaId, EquipmentId)

	CONSTRAINT [FK_Inventory_ToNinja] FOREIGN KEY (NinjaId) REFERENCES Ninja(Id) ON DELETE CASCADE,
	CONSTRAINT [FK_Inventory_ToEquipment] FOREIGN KEY (EquipmentId) REFERENCES Equipment(Id) ON DELETE CASCADE

)
