use GestTrackDB
Select * from GestTrack.Funcionario

create function GestTrack.calcBillValue (@billCode as int) returns float as
begin
	declare @valor float
	Select @valor= Sum(Mat.valor) from GestTrack.Fatura as FACT join GestTrack.Material as Mat on fact.Numero=Mat.Fatura_Numero
	where fact.Numero=@billCode
	return @valor
end;
go;

select GestTrack.calcBillValue(1)
go

create function GestTrack.calcIvaValue (@billCode as int) returns float as
begin
	declare @valor float
	Select @valor= Sum(Mat.iva) from GestTrack.Fatura as FACT join GestTrack.Material as Mat on fact.Numero=Mat.Fatura_Numero
	where fact.Numero=@billCode
	return @valor
end;
go
select GestTrack.calcIvaValue(1)
go





