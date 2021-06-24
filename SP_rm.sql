use GestTrackDB
go
drop procedure GestTrack.AllEmployes 
go
drop procedure GestTrack.employeeByName
go
drop procedure GestTrack.employeeByNif
go
drop procedure GestTrack.employesSupervisedByNif
go
drop procedure GestTrack.employesSupervisedByName
go
drop procedure GestTrack.AllWarehouse 
go
drop procedure GestTrack.WarehouseByName 
go
drop procedure GestTrack.WarehouseByAddress
go
drop procedure GestTrack.WarehouseByEmployee
go
drop procedure GestTrack.AllClients
go
drop procedure GestTrack.clientByName  
go
drop procedure GestTrack.ClientByNif
go
drop procedure GestTrack.AllActivities
go
drop procedure GestTrack.activitiesByName
go
drop procedure GestTrack.activitiesByDescription
go
drop procedure GestTrack.activitiesByClient
go
drop procedure GestTrack.activitiesByClientNif 
go
drop procedure GestTrack.activitieByEmployee
go	
drop procedure GestTrack.AllMovements 
go
drop procedure GestTrack.movementByName
go
drop procedure GestTrack.movementByDescription
go
drop procedure GestTrack.movementByEmployee
go	
drop procedure GestTrack.movementByActivity
go	
drop procedure GestTrack.AllBills
go
drop procedure GestTrack.billsByName
go
drop procedure GestTrack.billsByDescription
go
drop procedure GestTrack.billByMovementCode
go	
drop procedure GestTrack.billByMovement
go	
drop procedure GestTrack.billsByActivity
go	
drop procedure GestTrack.AllMaterial 
go
drop procedure GestTrack.MaterialByName
go
drop procedure GestTrack.materialInsideMaterial
go
drop procedure GestTrack.materialInsideMaterialCode
go
drop procedure GestTrack.materialByCategory
go
drop procedure GestTrack.materialByCategoryName 
go
drop procedure GestTrack.MaterialByWarehouse
go
drop procedure GestTrack.MaterialByBill
go	
drop procedure GestTrack.AllBudget 
go
drop procedure GestTrack.budgetByName 
go
drop procedure GestTrack.budgetByActivityName 
go
drop procedure GestTrack.budgetByActivity 
go
drop procedure GestTrack.budgetByClientName 
go
drop procedure GestTrack.budgetByClient  
go
drop procedure GestTrack.MaterialByBudgetName 
go	
drop procedure GestTrack.MaterialByBudget 
go
drop procedure GestTrack.budgetByMaterial 
go	
drop procedure GestTrack.budgetByMaterialName 
go	
drop procedure GestTrack.materialByActivity 
go
drop procedure GestTrack.materialByActivityCode 
go	