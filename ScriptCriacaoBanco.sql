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
	telefone int not null
)
GO 

create table Professor
(
	id int identity(1,1) primary key,
	nome varchar(150) not null,
	matricula int not null,
	email varchar(50)
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
	idSalaProfessorRelacional int not null,
	nome varchar(100) not null,
	matricula int not null,
	
	CONSTRAINT FK_Responsavel_Aluno FOREIGN KEY (idResponsavel)
	REFERENCES Responsavel (id),
	CONSTRAINT FK_SalaProfessorRelacional_Aluno FOREIGN KEY (idSalaProfessorRelacional)
	REFERENCES SalaProfessorRelacional (id)
)
GO