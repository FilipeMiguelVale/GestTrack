use GestTrackDB
go

create procedure GestTrack.AllEmployes as
begin
	select * from GestTrack.Funcionario
end;
go

exec GestTrack.AllEmployes
go

create procedure GestTrack.employeeByName @nome as varchar(256) as
begin
	select * from GestTrack.Funcionario where nome like '%'+@nome+'%'
end;
go

exec GestTrack.employeeByName 'Filipe '
go

create procedure GestTrack.employeeByNif @nif as int as
begin
	select * from GestTrack.Funcionario where nif=@nif
end;
go

exec GestTrack.employeeByNif '10000001'
go

create procedure GestTrack.employesSupervisedByNif @nif as int as
begin
	declare @super int;
	set @super =(select N_Interno from GestTrack.Funcionario where nif=@nif );
	print @super;
	select * from GestTrack.Funcionario where Super_interno=@super
end;
go
exec GestTrack.employesSupervisedByNif '10000001'
go

create procedure GestTrack.employesSupervisedByName @nome as varchar(256)as
begin
	declare @super int;
	set @super =(select N_Interno from GestTrack.Funcionario where nome like '%'+@nome+'%' );
	print @super;
	select * from GestTrack.Funcionario where Super_interno=@super
end;
go
exec GestTrack.employesSupervisedByName 'Filipe'
go

create procedure GestTrack.AllWarehouse as
begin
	select * from GestTrack.Armazem
end;
go
exec GestTrack.AllWarehouse
go

create procedure GestTrack.WarehouseByName @nome as varchar(256) as
begin
	select * from GestTrack.Armazem where nome like '%'+@nome+'%'
end;
go

exec GestTrack.WarehouseByName 'Pavilhao'
go

create procedure GestTrack.WarehouseByAddress @Morada as varchar(256) as
begin
	select * from GestTrack.Armazem where Morada like '%'+@Morada+'%'
end;
go

exec GestTrack.WarehouseByAddress 'Seia'
go

create procedure GestTrack.WarehouseByEmployee @nome as varchar(256)as
begin
	declare @super int;
	set @super =(select N_Interno from GestTrack.Funcionario where nome like '%'+@nome+'%' );
	print @super;
	Select Arm.Codigo, arm.Nome, arm.Morada, arm.Telemovel
	from GestTrack.Funcionario as Func join GestTrack.Funcionario_Usa as FA on Func.N_Interno=FA.Codigo_Func
		join GestTrack.Armazem as Arm on FA.Codigo_Arm = Arm.Codigo where FA.Codigo_Func=@super
end;
go
exec GestTrack.WarehouseByEmployee 'Filipe'
go

create procedure GestTrack.AllClients as
begin
	select * from GestTrack.Cliente
end;
go

exec GestTrack.AllClients
go

create procedure GestTrack.clientByName @nome as varchar(256) as
begin
	select * from GestTrack.Cliente where nome like '%'+@nome+'%'
end;
go

exec GestTrack.clientByName 'Camara '
go

create procedure GestTrack.ClientByNif @nif as int as
begin
	select * from GestTrack.Cliente where nif=@nif
end;
go

exec GestTrack.ClientByNif '20000001'
go


create procedure GestTrack.AllActivities as
begin
	select * from GestTrack.Atividade
end;
go

exec GestTrack.AllActivities
go

create procedure GestTrack.activitiesByName @nome as varchar(256) as
begin
	select * from GestTrack.Atividade where nome like '%'+@nome+'%'
end;
go

exec GestTrack.activitiesByName 'Jazz '
go

create procedure GestTrack.activitiesByDescription @Descricao as varchar(256) as
begin
	select * from GestTrack.Atividade where Descricao like '%'+@Descricao+'%'
end;
go

exec GestTrack.activitiesByDescription 'Seia'
go

create procedure GestTrack.activitiesByClient @nome as varchar(256)as
begin
	Select Act.Codigo, act.nome, act.Descricao, act.Data_Inicio, act.Data_Fim
	from GestTrack.Atividade as ACT join GestTrack.Cliente as Cli on ACT.Cliente=Cli.Nif
		 where cli.nome like '%'+@nome+'%'
end;
go
exec GestTrack.activitiesByClient 'camara'
go

create procedure GestTrack.activitiesByClientNif  @nif as int as
begin

	Select Act.Codigo, act.nome, act.Descricao, act.Data_Inicio, act.Data_Fim
	from GestTrack.Atividade as ACT join GestTrack.Cliente as Cli on ACT.Cliente=Cli.Nif
		 where Cli.Nif=@nif
end;
go
exec GestTrack.activitiesByClientNif '20000004'
go

create procedure GestTrack.activitieByEmployee @nome as varchar(256)as
begin
	declare @super int;
	set @super =(select N_Interno from GestTrack.Funcionario where nome like '%'+@nome+'%' );
	print @super;
	Select  Act.Codigo, act.nome, act.Descricao, act.Data_Inicio, act.Data_Fim
	from GestTrack.Funcionario as Func join GestTrack.Atividades_Realizadas as AR on Func.N_Interno=AR.Codigo_Funcionario
		join GestTrack.Atividade as ACT on AR.Codigo_Atividade = ACt.Codigo where AR.Codigo_Funcionario=@super
end;
go
exec GestTrack.activitieByEmployee 'Nuno'
go	


create procedure GestTrack.AllMovements as
begin
	select * from GestTrack.Movimento
end;
go

exec GestTrack.AllMovements
go

create procedure GestTrack.movementByName @nome as varchar(256) as
begin
	select * from GestTrack.Movimento where nome like '%'+@nome+'%'
end;
go

exec GestTrack.movementByName 'som '
go

create procedure GestTrack.movementByDescription @Descricao as varchar(256) as
begin
	select * from GestTrack.Movimento where Descricao like '%'+@Descricao+'%'
end;
go

exec GestTrack.movementByDescription 'Seia'
go

create procedure GestTrack.movementByEmployee @nome as varchar(256)as
begin
	Select Mov.Codigo,mov.Nome, mov.Descricao, Mov.Data, mov.Codigo_Funcionario, mov.Codigo_Atividade
	from GestTrack.Movimento as Mov join GestTrack.Funcionario as Fun on Mov.Codigo_Funcionario=Fun.N_Interno
		 where Fun.nome like '%'+@nome+'%'
end;
go
exec GestTrack.movementByEmployee 'Filipe'
go	

create procedure GestTrack.movementByActivity @nome as varchar(256)as
begin
	declare @super int;
	set @super =(select top 1 codigo from GestTrack.Atividade where nome like '%'+@nome+'%' );
	print @super;
	Select Mov.Codigo,mov.Nome, mov.Descricao, Mov.Data, mov.Codigo_Funcionario, mov.Codigo_Atividade
	from GestTrack.Movimento as Mov join GestTrack.Atividade as ACT on Mov.Codigo_Atividade=act.Codigo
		 where mov.Codigo_Atividade=@super
end;
go
exec GestTrack.movementByActivity 'Festival Internacional 2018'
go	


create procedure GestTrack.AllBills as
begin
	select * from GestTrack.Fatura
end;
go

exec GestTrack.AllBills
go

create procedure GestTrack.billsByName @nome as varchar(256) as
begin
	select * from GestTrack.Fatura where nome like '%'+@nome+'%'
end;
go

exec GestTrack.billsByName 'som '
go

create procedure GestTrack.billsByDescription @Descricao as varchar(256) as
begin
	select * from GestTrack.Fatura where Descricao like '%'+@Descricao+'%'
end;
go

exec GestTrack.billsByDescription 'Jazz'
go

create procedure GestTrack.billByMovementCode @codigo as int as
begin
	Select mov.Codigo, mov.Nome, mov.Descricao, mov.Data, mov.Codigo_Atividade, mov.Codigo_Funcionario
	from GestTrack.Fatura as Fact join GestTrack.Movimento as Mov on Fact.Codigo_Movimento=Mov.Codigo
		 where Mov.Codigo=@codigo
end;
go
exec GestTrack.billByMovementCode '3'
go	

create procedure GestTrack.billByMovement @nome as varchar(256)as
begin
	Select mov.Codigo, mov.Nome, mov.Descricao, mov.Data, mov.Codigo_Atividade, mov.Codigo_Funcionario
	from GestTrack.Fatura as Fact join GestTrack.Movimento as Mov on Fact.Codigo_Movimento=Mov.Codigo
		 where Mov.nome like '%'+@nome+'%'
end;
go
exec GestTrack.billByMovement 'Compra som'
go	

create procedure GestTrack.billsByActivity @nome as varchar(256)as
begin
	Select Fact.Numero, fact.Nome, fact.Descricao, fact.data, fact.Codigo_Movimento
	select * 
	from GestTrack.Fatura as Fact join GestTrack.Movimento as Mov on Fact.Codigo_Movimento=Mov.Codigo join 
	GestTrack.Atividade as ACT on Mov.Codigo_Atividade=ACT.Codigo
		 where ACT.nome like '%'+@nome+'%'
end;
go
exec GestTrack.billsByActivity 'Jazz and blues Seia XII '
go	

create procedure GestTrack.AllMaterial as
begin
	select * from GestTrack.Material
end;
go

exec GestTrack.AllMaterial
go

create procedure GestTrack.MaterialByName @nome as varchar(256) as
begin
	select * from GestTrack.Material where nome like '%'+@nome+'%'
end;
go

exec GestTrack.MaterialByName 'cabo'
go

create procedure GestTrack.materialInsideMaterial @nome as varchar(256)as
begin
	declare @super int;
	set @super =(select Top 1 Codigo from GestTrack.Material where nome like '%'+@nome+'%' );
	print @super;
	select * from GestTrack.Material where Super_Codigo=@super
end;
go
exec GestTrack.materialInsideMaterial 'Caixa'
go

create procedure GestTrack.materialInsideMaterialCode @codigo as int as
begin
		select * from GestTrack.Material where Super_Codigo=@codigo
end;
go
exec GestTrack.materialInsideMaterialCode '1'
go

create procedure GestTrack.materialByCategory @codigo as int as
begin
		select * from GestTrack.Material where Categoria=@codigo
end;
go
exec GestTrack.materialByCategory '2'
go

create procedure GestTrack.materialByCategoryName @nome as varchar(50) as
begin	
		declare @codigo as int;

		set @codigo = Case @nome
			when 'Cabos' then 1
			when 'Som' then 2
			when 'Luzes' then 3
			when 'Caixas' then 4
		end; 
		select * from GestTrack.Material where Categoria=@codigo
end;
go
exec GestTrack.materialByCategoryName 'Cabos'
go

create procedure GestTrack.MaterialByWarehouse @nome as varchar(256) as
begin

	Select Mat.*
	from GestTrack.Material as Mat join GestTrack.Armazem as ARM on Mat.Codigo_Armazem=ARM.Codigo
		 where ARM.Nome like '%'+@nome+'%'
end;
go

exec GestTrack.MaterialByWarehouse 'pavilhao1'
go

create procedure GestTrack.MaterialByBill @numero as int as
begin
	Select Mat.*
	from GestTrack.Material as Mat join GestTrack.Fatura as FA on Mat.Fatura_Numero=FA.Numero
	where fa.Numero=@numero
end;
go
exec GestTrack.MaterialByBill '1'
go	


create procedure GestTrack.AllBudget as
begin
	select * from GestTrack.Orcamento
end;
go

exec GestTrack.AllBudget
go

create procedure GestTrack.budgetByName @nome as varchar(256) as
begin
	select * from GestTrack.Orcamento where nome like '%'+@nome+'%'
end;
go

exec GestTrack.budgetByName 'VMP'
go

create procedure GestTrack.budgetByActivityName @nome as varchar(256)as
begin
	select orca.* from GestTrack.Orcamento as ORCA join GestTrack.Atividade as ACT on  ORCA.Atividade_Codigo=ACT.Codigo
	 where ACT.nome like '%'+@nome+'%'
end;
go
exec GestTrack.budgetByActivityName 'Festival'
go

create procedure GestTrack.budgetByActivity @codigo as int as
begin
		select * from GestTrack.Orcamento where Atividade_Codigo=@codigo
end;
go
exec GestTrack.budgetByActivity '13'
go

create procedure GestTrack.budgetByClientName @nome as varchar(256) as
begin
		select orca.* , cli.Nif 
		from GestTrack.Orcamento as ORCA join GestTrack.Atividade as ACT on  ORCA.Atividade_Codigo=ACT.Codigo 
		join GestTrack.Cliente as CLI on ACT.Cliente=CLI.Nif
	 where CLI.nome like '%'+@nome+'%'
end;
go
exec GestTrack.budgetByClientName 'Vozes'
go

create procedure GestTrack.budgetByClient @nif as int as
begin
		select orca.* , cli.Nif 
		from GestTrack.Orcamento as ORCA join GestTrack.Atividade as ACT on  ORCA.Atividade_Codigo=ACT.Codigo 
		join GestTrack.Cliente as CLI on ACT.Cliente=CLI.Nif
	 where CLI.Nif=@nif
end;
go
exec GestTrack.budgetByClient '20000001'
go

create procedure GestTrack.MaterialByBudgetName @nome as varchar(256)as
begin
	Select  *
	from GestTrack.Orcamento as orca join GestTrack.Orcamento_Material as orcam on orca.Codigo=orcam.Codigo_Orcamento
	join GestTrack.Material as Mat on orcam.Codigo_Material=mat.Codigo 
	where orca.Nome like '%'+@nome+'%'
end;
go
exec GestTrack.MaterialByBudgetName 'Orçamento Jazz and blues Seia XII'
go	

create procedure GestTrack.MaterialByBudget @codigo as int as
begin
	Select  Mat.*
	from GestTrack.Orcamento as orca join GestTrack.Orcamento_Material as orcam on orca.Codigo=orcam.Codigo_Orcamento
	join GestTrack.Material as Mat on orcam.Codigo_Material=mat.Codigo 
	where orca.Codigo=@codigo
end;
go
exec GestTrack.MaterialByBudget '2'
go

create procedure GestTrack.budgetByMaterial @codigo as int as
begin
	Select  orca.*
	from GestTrack.Material as Mat join GestTrack.Orcamento_Material as orcam on orcam.Codigo_Material=mat.Codigo
	join   GestTrack.Orcamento as orca  on orca.Codigo=orcam.Codigo_Orcamento
	where mat.Codigo=@codigo
end;
go
exec GestTrack.budgetByMaterial '2'
go	

create procedure GestTrack.budgetByMaterialName @nome as varchar(256) as
begin
	Select  orca.*, mat.Nome, mat.Codigo
	from GestTrack.Material as Mat join GestTrack.Orcamento_Material as orcam on orcam.Codigo_Material=mat.Codigo
	join   GestTrack.Orcamento as orca  on orca.Codigo=orcam.Codigo_Orcamento
	where mat.Nome like '%'+@nome+'%'
end;
go
exec GestTrack.budgetByMaterialName 'Cabo dmx azul 2m'
go	



create procedure GestTrack.materialByActivity @nome as varchar(256) as
begin
	Select  Mat.*, Act.nome
	from GestTrack.Material as Mat join GestTrack.Material_Atividade as mata on mata.Codigo_Material=mat.Codigo
	join   GestTrack.Atividade as ACT  on mata.Codigo_Atividade=act.Codigo
	where act.Nome like '%'+@nome+'%'
end;
go
exec GestTrack.materialByActivity 'Jazz and blues Seia XIII'
go

create procedure GestTrack.materialByActivityCode @codigo as int as
begin
	Select  Mat.*, Act.nome
	from GestTrack.Material as Mat join GestTrack.Material_Atividade as mata on mata.Codigo_Material=mat.Codigo
	join   GestTrack.Atividade as ACT  on mata.Codigo_Atividade=act.Codigo
	where act.Codigo=@codigo
end;
go
exec GestTrack.materialByActivityCode '2'
go	



