use GestTrackDB
go

insert into GestTrack.Funcionario (Nome,Email,Nif,Morada,DNasc,Telemovel,Super_Interno)values
	('Filipe Miguel Marques Vale','filipevale@ua.pt','10000001','Seia','1997-11-18','912345678',Null),
	('Antonio JC Fragoso','muv@sapo.pt','10000002','Seia','1997-11-19','912345679',1),
	('Nuno Manuel Rodrigues','geral@jndprodm.com','10000003','Oliveira de Frades','1997-11-20','912345680',1),
	('Pedro Sim�es','filipevale@ua.pt','10000004','Viseu','1997-11-21','912345681',1)
go
select * from GestTrack.Funcionario
/*delete from GestTrack.Funcionario*/

insert into GestTrack.Armazem (Nome,Morada,Telemovel)values
	('Pavilhao1','Seia','922345678'),
	('pavilhao2','Oliveira de Frades','922345678'),
	('CACE','Seia',Null)

go
select * from GestTrack.Armazem
/*delete from GestTrack.Armazem*/

insert into GestTrack.Funcionario_Usa (Codigo_Func,Codigo_Arm)values
	('1','1'),
	('1','3'),
	('2','3'),
	('2','1'),
	('3','1'),
	('3','2')

go
select * from GestTrack.Funcionario_Usa
/*delete from GestTrack.Funcionario_Usa*/


select Func.N_Interno, Func.Nome,FA.Codigo_Arm,Arm.Nome
from GestTrack.Funcionario as Func join GestTrack.Funcionario_Usa as FA on Func.N_Interno=FA.Codigo_Func
	join GestTrack.Armazem as Arm on FA.Codigo_Arm = Arm.Codigo
group by Func.N_Interno, Func.Nome,FA.Codigo_Arm,Arm.Nome

insert into GestTrack.Cliente (Nome,Email,Nif,Morada,Telemovel)values
	('Camara Municipal de Seia','geral@cms.pt','20000001','Seia','238123456'),
	('Camara Municipal de oliveira de Frades','geral@cmof.pt','20000002','Oliveira de Frades','238123455'),
	('Rancho folclorico','','20000003','Seia','238423456'),
	('Vozes em Meia Ponta','geral@vmp.pt','20000004','Seia','238163456'),
	('David Rodrigues','david99@gmail.com','20000005','Seia','238123456'),
	('GPS BAND','GPS@gmail.com','20000006','Seia','238123434')
go
select * from GestTrack.Cliente
/*delete from GestTrack.Cliente*/

insert into GestTrack.Atividade (Nome,Descricao,Data_Inicio,Data_Fim,Cliente)values
	('Jazz and blues Seia XII ','edicao XII ','2016-3-10','2016-3-12','20000001'),
	('Jazz and blues Seia XIII ','edicao XIII ','2017-3-9','2017-3-12','20000001'),
	('Jazz and blues Seia XIV ','edicao XIV ','2018-3-8','2018-3-10','20000001'),
	('Jazz and blues Seia XV ','edicao XV ','2019-3-21','2019-3-24','20000001'),
	('Jazz and blues Seia XVI ','edicao XVI open AIR','2021-7-2','2021-7-4','20000001'),
	('Atua��o GPS Pindelo ','Pindelo ','2019-4-21','2019-4-21','20000006'),
	('Atua��o GPS Manhouce','Manhouce','2019-5-18','2019-5-19','20000006'),
	('Atua��o GPS Pindelo','Pindelo ','2019-6-8','2019-6-9','20000006'),
	('Atua��o GPS Fiais','Fiais ','2019-6-22','2019-6-22','20000006'),
	('Festival Internacional 2018','Seia','2018-6-22','2018-6-22','20000003'),
	('Festival Internacional 2019','Seia','2019-6-2','2019-6-2','20000003'),
	('Festival VMP','Seia','2019-7-2','2019-7-2','20000004'),
	('Festival VMP','Seia','2020-6-15','2019-6-15','20000004')

go
select * from GestTrack.Atividade
/*delete from GestTrack.Atividade*/


select * from GestTrack.Funcionario

insert into GestTrack.Atividades_Realizadas (Codigo_Funcionario,Codigo_Atividade)values
	('1','1'),('2','1'),('3','1'),('4','1'),
	('1','2'),('2','2'),('3','2'),
	('1','3'),('2','3'),('3','3'),
	('1','4'),('2','4'),('3','4'),('4','4'),
	('1','5'),('2','5'),('3','5'),
	('1','6'),
	('1','7'),
	('1','8'),
	('1','9'),
	('1','10'),('2','10'),('3','10'),
	('1','11'),('2','11'),('3','11'),
	('1','12'),('2','12'),('3','12'),('4','12'),
	('1','13'),('2','13'),('3','13')

go
select * from GestTrack.Atividades_Realizadas
/*delete from GestTrack.Atividades_Realizadas*/

select Func.N_Interno, Func.Nome,AR.Codigo_Atividade,ACT.Nome
from GestTrack.Funcionario as Func join GestTrack.Atividades_Realizadas as AR on Func.N_Interno=AR.Codigo_Funcionario
	join GestTrack.Atividade as ACT on AR.Codigo_Atividade = ACT.Codigo
group by Func.N_Interno, Func.Nome,AR.Codigo_Atividade,ACT.Nome


select * from GestTrack.Funcionario

insert into GestTrack.Movimento (Nome,Descricao,[Data],Codigo_Funcionario,Codigo_Atividade)values
	('Compra cabos ','Jazz and blues Seia XII ','2016-3-10','1','1'),
	('Compra colunas ','Jazz and blues Seia XIII ','2017-3-9','2','2'),
	('Compra luzes ','Jazz and blues Seia XIV ','2018-3-8','3','3'),
	('Compra luzes ','Jazz and blues Seia XV ','2019-3-21','2','4'),
	('Compra Som ','Jazz and blues Seia XVI ','2021-7-2','3','5'),
	('Compra cabos ','Festival Internacional 2018 Seia','2018-6-22','2','10'),
	('Compra Som ','Festival Internacional 2019 Seia','2019-6-2','2','11'),
	('Compra Microfones ','Festival VMP Seia','2019-7-2','1','12'),
	('Compra material ','Festival VMP Seia','2020-6-15','1','13')
	
go
select * from GestTrack.Movimento
--delete from GestTrack.Movimento

insert into GestTrack.Fatura (Numero,Nome,Descricao,[Data],Codigo_Movimento)values
	(1,'Compra cabos luz ','Jazz and blues Seia XII ','2016-3-10','1'),
	(2,'Compra cabos som ','Jazz and blues Seia XII ','2016-3-10','1'),
	(3,'Compra colunas ','Jazz and blues Seia XIII ','2017-3-9','2'),
	(4,'Compra luzes ','Jazz and blues Seia XIV ','2018-3-8','3'),
	(5,'Compra luzes ','Jazz and blues Seia XV ','2019-3-21','4'),
	(6,'Compra Som ','Jazz and blues Seia XVI ','2021-7-2','5'),
	(7,'Compra cabos ','Festival Internacional 2018 Seia','2018-6-22','6'),
	(8,'Compra Som ','Festival Internacional 2019 Seia','2019-6-2','7')
	
go
select * from GestTrack.Fatura
--delete from GestTrack.Fatura
insert into GestTrack.Material (Nome,Categoria,valor, iva,Super_Codigo,Fatura_Numero,Codigo_Armazem)values
	('Caixa Cabos',4,'100','23',Null,1,1),
	('Cabo dmx azul 2m',1,'3','0.69',1,1,1),
	('Cabo dmx branco 3m',1,'5.9','1.36',1,1,1),
	('Cabo dmx vermelho 10m',1,'6.9','1.59',1,1,1),
	('Cabo microfone ',1,'100','23',Null,2,2),
	('Behringer B115D ',2,'215','49.45',Null,3,2),
	('Beam 7r primsa duplo ',3,'390','0',Null,4,2),
	('Wash 36*18w RGBWA+UV ',3,'300','',Null,5,2),
	('Behringer B115D ',2,'215','49.45',Null,6,1),
	('Cabo microfone 5m',1,'100','23',Null,7,3),
	('Microfone Sure Sm58',2,'200','46',Null,8,1)
go
select * from GestTrack.Material

insert into GestTrack.Orcamento (Nome,Validade,valor,iva,Data_Realizado,Atividade_Codigo)values
	('Or�amento Jazz and blues Seia XII ',30,'1000','230','2016-3-10',1),
	('Or�amento Jazz and blues Seia XIII ',30,'500','115','2017-3-9',2),
	('Or�amento Jazz and blues Seia XIV ',30,'1500','345','2018-3-8',3),
	('Or�amento Jazz and blues Seia XV ',30,'1000','230','2019-3-21',4),
	('Or�amento Jazz and blues Seia XVI ',30,'3000','690','2021-7-2',5),
	('Or�amento Festival Internacional 2018',30,'500','115','2018-6-22',10),
	('Or�amento Festival Internacional 2019',30,'1000','230','2019-6-2',11),
	('Or�amento Festival VMP',30,'1000','230','2019-7-2',12),
	('Or�amento Som Festival VMP',30,'1000','230','2020-6-15',13),
	('Or�amento Som + Luzes Festival VMP',30,'2000','460','2020-6-15',13)

go
select * from GestTrack.Orcamento
/*delete from GestTrack.Orcamento*/

insert into GestTrack.Orcamento_Material (Codigo_Orcamento,Codigo_Material)values
	(1,1),(1,2),(1,7),(1,8),(1,9),(1,10),(1,11),
	(2,1),(2,2),(2,3),(2,4),(2,5),(2,6),(2,7),(2,8),(2,9),
	(3,1),(3,2),(3,3),(3,4),(3,5),(3,6),(3,7),(3,8),(3,10),(3,11),
	(4,1),(4,2),(4,4),(4,5),(4,6),(4,7),(4,8),
	(5,1),(5,3),(5,4),(5,5),(5,7),(5,8),(5,9),(5,10),(5,11),
	(6,1),(6,2),(6,3),(6,4),(6,5),(6,6),(6,7),(6,8),(6,9),(6,10),(6,11),
	(7,1),(7,2),(7,3),(7,4),(7,5),(7,6),(7,7),(7,8),(7,9),
	(8,1),(8,2),(8,3),(8,4),(8,5),(8,7),(8,8),(8,9),
	(9,5),(9,6),(9,7),(9,8),(9,10),(9,11),
	(10,1),(10,2),(10,3),(10,4),(10,5),(10,6),(10,7),(10,8),(10,9),(10,10),(10,11)

go
select * from GestTrack.Orcamento_Material
--delete from GestTrack.Orcamento_Material

insert into GestTrack.Material_Atividade (Codigo_Atividade,Codigo_Material,Data_Entrada,Data_Saida)values
	(1,1,'2016-3-10','2016-3-12'),(1,2,'2016-3-10','2016-3-12'),(1,7,'2016-3-10','2016-3-12'),(1,8,'2016-3-10','2016-3-12'),(1,9,'2016-3-10','2016-3-12'),(1,10,'2016-3-10','2016-3-12'),(1,11,'2016-3-10','2016-3-12'),
	(2,1,'2017-3-9','2017-3-12'),(2,2,'2017-3-9','2017-3-12'),(2,3,'2017-3-9','2017-3-12'),(2,4,'2017-3-9','2017-3-12'),(2,5,'2017-3-9','2017-3-12'),(2,6,'2017-3-9','2017-3-12'),(2,7,'2017-3-9','2017-3-12'),(2,8,'2017-3-9','2017-3-12'),(2,9,'2017-3-9','2017-3-12'),
	(3,1,'2018-3-8','2018-3-10'),(3,2,'2018-3-8','2018-3-10'),(3,3,'2018-3-8','2018-3-10'),(3,4,'2018-3-8','2018-3-10'),(3,5,'2018-3-8','2018-3-10'),(3,6,'2018-3-8','2018-3-10'),(3,7,'2018-3-8','2018-3-10'),(3,8,'2018-3-8','2018-3-10'),(3,10,'2018-3-8','2018-3-10'),(3,11,'2018-3-8','2018-3-10'),
	(4,1,'2019-3-21','2019-3-24'),(4,2,'2019-3-21','2019-3-24'),(4,4,'2019-3-21','2019-3-24'),(4,5,'2019-3-21','2019-3-24'),(4,6,'2019-3-21','2019-3-24'),(4,7,'2019-3-21','2019-3-24'),(4,8,'2019-3-21','2019-3-24'),
	(5,1,'2021-7-2','2021-7-4'),(5,3,'2021-7-2','2021-7-4'),(5,4,'2021-7-2','2021-7-4'),(5,5,'2021-7-2','2021-7-4'),(5,7,'2021-7-2','2021-7-4'),(5,8,'2021-7-2','2021-7-4'),(5,9,'2021-7-2','2021-7-4'),(5,10,'2021-7-2','2021-7-4'),(5,11,'2021-7-2','2021-7-4'),
	(10,1,'2018-6-22','2018-6-22'),(10,2,'2018-6-22','2018-6-22'),(10,3,'2018-6-22','2018-6-22'),(10,4,'2018-6-22','2018-6-22'),(10,5,'2018-6-22','2018-6-22'),(10,6,'2018-6-22','2018-6-22'),(10,7,'2018-6-22','2018-6-22'),(10,8,'2018-6-22','2018-6-22'),(10,9,'2018-6-22','2018-6-22'),(10,10,'2018-6-22','2018-6-22'),(10,11,'2018-6-22','2018-6-22'),
	(11,1,'2019-6-2','2019-6-2'),(11,2,'2019-6-2','2019-6-2'),(11,3,'2019-6-2','2019-6-2'),(11,4,'2019-6-2','2019-6-2'),(11,5,'2019-6-2','2019-6-2'),(11,6,'2019-6-2','2019-6-2'),(11,7,'2019-6-2','2019-6-2'),(11,8,'2019-6-2','2019-6-2'),(11,9,'2019-6-2','2019-6-2'),
	(12,1,'2019-7-2','2019-7-2'),(12,2,'2019-7-2','2019-7-2'),(12,3,'2019-7-2','2019-7-2'),(12,4,'2019-7-2','2019-7-2'),(12,5,'2019-7-2','2019-7-2'),(12,7,'2019-7-2','2019-7-2'),(12,8,'2019-7-2','2019-7-2'),(12,9,'2019-7-2','2019-7-2'),
	(13,1,'2020-6-15','2019-6-15'),(13,2,'2020-6-15','2019-6-15'),(13,3,'2020-6-15','2019-6-15'),(13,4,'2020-6-15','2019-6-15'),(13,5,'2020-6-15','2019-6-15'),(13,6,'2020-6-15','2019-6-15'),(13,7,'2020-6-15','2019-6-15'),(13,8,'2020-6-15','2019-6-15'),(13,9,'2020-6-15','2019-6-15'),(13,10,'2020-6-15','2019-6-15'),(13,11,'2020-6-15','2019-6-15')

go
select * from GestTrack.Material_Atividade

--delete from GestTrack.Material_Atividade
