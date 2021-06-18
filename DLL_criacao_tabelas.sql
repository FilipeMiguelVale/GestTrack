--create database GestTrackDB
go
use GestTrackDB
go

CREATE SCHEMA GestTrack;
go
CREATE TABLE GestTrack.Funcionario (
	N_Interno	int IDENTITY(1,1) primary key ,
	Nome varchar(256) not null,
	Email Varchar(256) not null,
	Nif int not null,
	Morada varchar(256) not null,
	DNasc date not null,
	Telemovel varchar(15) not null,
	Super_Interno int
);
go
CREATE TABLE GestTrack.Armazem (
	Codigo int IDENTITY(1,1) primary key ,
	Nome varchar(256) not null,
	Morada varchar(256) not null,
	Telemovel varchar(15),
);
go
CREATE TABLE GestTrack.Funcionario_Usa (
	Codigo_Func	 int foreign key references GestTrack.Funcionario(N_Interno),
	Codigo_Arm	 int foreign key references GestTrack.Armazem(Codigo),
	primary key(Codigo_Func, Codigo_Arm),
);
go
CREATE TABLE GestTrack.Cliente (
	Nif int primary key,
	Nome varchar(256) not null,
	Email Varchar(256) not null,
	Morada varchar(256) not null,
	Telemovel varchar(15) not null,
);
go
CREATE TABLE GestTrack.Atividade (
	Codigo int IDENTITY(1,1) primary key ,
	Nome varchar(256) not null,
	Descricao varchar(256) ,
	Data_Inicio DATETIME not null ,
	Data_Fim DATETIME ,
	Cliente	 int foreign key references GestTrack.Cliente(NIF),
	--check if Data_Fim != Null && Data_Fim > Data_inicio
);
go
CREATE TABLE GestTrack.Atividades_Realizadas (
	Codigo_Funcionario	 int foreign key references GestTrack.Funcionario(N_Interno),
	Codigo_Atividade	 int foreign key references GestTrack.Atividade(Codigo),
	primary key(Codigo_Funcionario, Codigo_Atividade),
);
go
CREATE TABLE GestTrack.Movimento (
	Codigo int IDENTITY(1,1) primary key ,
	Nome varchar(256) not null,
	Descricao varchar(256) not null,
	[Data] DATETIME not null ,
	Codigo_Funcionario	 int foreign key references GestTrack.Funcionario(N_Interno),
	Codigo_Atividade	 int foreign key references GestTrack.Atividade(Codigo)
);
go
CREATE TABLE GestTrack.Fatura (
	Numero int primary key ,
	Nome varchar(256) not null,
	Descricao varchar(256) not null,
	[Data] DATETIME not null ,
	Codigo_Movimento	 int foreign key references GestTrack.Movimento(Codigo)
);
go
CREATE TABLE GestTrack.Material (
	Codigo int IDENTITY(1,1) primary key, 
	Nome varchar(256) not null,
	Categoria int not null,
	valor float not null,
	iva float not null,
	Super_Codigo int,
	Fatura_Numero int foreign key references GestTrack.Fatura(Numero),
	Codigo_Armazem	 int foreign key references GestTrack.Armazem(Codigo)
);
go
CREATE TABLE GestTrack.Orcamento (
	Codigo int IDENTITY(1,1) primary key, 
	Nome varchar(256) not null,
	Validade int not null,
	valor float not null,
	iva float not null,
	Data_Realizado datetime not null,
	Atividade_Codigo int foreign key references GestTrack.Atividade(Codigo)
);
go
CREATE TABLE GestTrack.Orcamento_Material (
	Codigo_Orcamento	 int foreign key references GestTrack.Orcamento(Codigo),
	Codigo_Material	 int foreign key references GestTrack.Material(Codigo),
	primary key(Codigo_Orcamento, Codigo_Material),
);
go
CREATE TABLE GestTrack.Material_Atividade(
	Codigo_Atividade int foreign key references GestTrack.Atividade(Codigo),
	Codigo_Material	 int foreign key references GestTrack.Material(Codigo),
	Data_Saida DATETIME ,
	Data_Entrada DATETIME not null ,
	primary key(Codigo_Atividade, Codigo_Material),
	--check if data saida != Null && data entrada > data saida 
);
go