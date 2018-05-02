CREATE DATABASE SchoolNotify
GO

USE SchoolNotify
GO

create table Sala 
(
	id int identity(1,1) primary key,
	nome varchar(100) not null,
	serie varchar(50) not null
)
GO

create table Responsavel
(
	id int identity(1,1) primary key,
	nome varchar(150) not null,
	email varchar(50) not null,
	telefone bigint not null
)
GO 

create table Professor
(
	id int identity(1,1) primary key,
	nome varchar(150) not null,
	matricula int unique not null,
	email varchar(50),
	telefone bigint not null
)
GO

create table SalaProfessorRelacional
(
	id int identity (1,1) primary key,
	idSala int not null,
	idProfessor int not null,

	CONSTRAINT FK_Sala_SalaProfessorRelacional FOREIGN KEY (idSala)     
    REFERENCES Sala (id),
	CONSTRAINT FK_Professor_SalaProfessorRelacional FOREIGN KEY (idProfessor)
	REFERENCES Professor (id)
)
GO

create table Aluno
(
	id int identity(1,1) primary key,
	idResponsavel int not null,
	idSala int not null,
	nome varchar(100) not null,
	matricula int unique not null,
	idade int not null,
	sexo varchar(10) not null,
	
	CONSTRAINT FK_Responsavel_Aluno FOREIGN KEY (idResponsavel)
	REFERENCES Responsavel (id),
	CONSTRAINT FK_Sala_Aluno FOREIGN KEY (idSala)
	REFERENCES Sala (id)
)
GO

create table Usuario
(
	id int identity(1,1) primary key,
	login varchar(50) not null,
	senha varchar(50) not null,
	telefone bigint null,
	responsavel bit null,
	professor bit null,
	admin bit null
)
GO

create table Notificacao
(
	id int identity(1,1) primary key,
	idProfessor int not null,
	idSala int null,
	idAluno int null,
	titulo varchar(30) not null,
	assunto varchar(30) not null,
	mensagem varchar(500) not null,
	data date not null,
	
	CONSTRAINT FK_Professor_Notificacao FOREIGN KEY (idProfessor)
	REFERENCES Professor (id),
	CONSTRAINT FK_Sala_Notificacao FOREIGN KEY (idSala)
	REFERENCES Sala (id),
	CONSTRAINT FK_Aluno_Notificacao FOREIGN KEY (idAluno)
	REFERENCES Aluno (id)
)
GO

insert into Usuario values('admin','admin',null,0,0,1)
GO