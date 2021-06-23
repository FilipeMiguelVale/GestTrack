use GestTrackDB
go;
drop procedure GestTrack.AllEmployes 
go;
drop procedure GestTrack.employeeByName
go;
drop procedure GestTrack.employeeByNif
go;
drop procedure GestTrack.employesSupervisedByNif @nif 
go;
drop procedure GestTrack.employesSupervisedByName @nome 
go
drop procedure GestTrack.AllWarehouse 
go
drop procedure GestTrack.WarehouseByName @nome
go
drop procedure GestTrack.WarehouseByAddress @Morada  
go
drop procedure GestTrack.WarehouseByEmployee @nome 
go
drop procedure GestTrack.AllClients
go
drop procedure GestTrack.clientByName @nome  
go
drop procedure GestTrack.ClientByNif @nif 
go
drop procedure GestTrack.AllActivities
go
drop procedure GestTrack.activitiesByName @nome
go
drop procedure GestTrack.activitiesByDescription @Descricao
go
drop procedure GestTrack.activitiesByClient @nome 
go
drop procedure GestTrack.activitiesByClientNif 
go
drop procedure GestTrack.activitieByEmployee @nome
go	
drop procedure GestTrack.AllMovements 
go
drop procedure GestTrack.movementByName @nome
go
drop procedure GestTrack.movementByDescription @Descricao
go
drop procedure GestTrack.movementByEmployee @nome 
go	
drop procedure GestTrack.movementByActivity @nome 
go	
drop procedure GestTrack.AllBills
go
drop procedure GestTrack.billsByName @nome 
go
drop procedure GestTrack.billsByDescription @Descricao
go
drop procedure GestTrack.billByMovementCode @codigo
go	
drop procedure GestTrack.billByMovement @nome
go	
drop procedure GestTrack.billsByActivity @nome 
go	
drop procedure GestTrack.AllMaterial 
go
drop procedure GestTrack.MaterialByName @nome
go
drop procedure GestTrack.materialInsideMaterial @nome
go
drop procedure GestTrack.materialInsideMaterialCode @codigo
go
drop procedure GestTrack.materialByCategory @codigo 
go
drop procedure GestTrack.materialByCategoryName @nome 
go
drop procedure GestTrack.MaterialByWarehouse @nome
go
drop procedure GestTrack.MaterialByBill @numero
go	
drop procedure GestTrack.AllBudget 
go
drop procedure GestTrack.budgetByName @nome 
go
drop procedure GestTrack.budgetByActivityName @nome 
go
drop procedure GestTrack.budgetByActivity @codigo 
go
drop procedure GestTrack.budgetByClientName @nome
go
drop procedure GestTrack.budgetByClient @nif 
go
drop procedure GestTrack.MaterialByBudgetName @nome
go	
drop procedure GestTrack.MaterialByBudget @codigo
go
drop procedure GestTrack.budgetByMaterial @codigo 
go	
drop procedure GestTrack.budgetByMaterialName @nome
go	
drop procedure GestTrack.materialByActivity @nome 
go
drop procedure GestTrack.materialByActivityCode @codigo 
go	