CREATE DATABASE sistemaDePontos;
GO

USE sistemaDePontos
GO

CREATE TABLE funcionarios (
	idFuncionario INT PRIMARY KEY IDENTITY,
	nome NVARCHAR(255),
	email NVARCHAR(255),
	senha NVARCHAR(255),
);
GO

CREATE TABLE diasDeTrabalho (
	idDia INT PRIMARY KEY IDENTITY,
	enderecoIP TEXT,
	idFuncionario INT FOREIGN KEY REFERENCES funcionarios(idFuncionario),
	entrada DATETIME2,
	intervaloEntrada DATETIME2,
	intervaloSaida DATETIME2,
	saida DATETIME2,
);
GO

CREATE TABLE historico (
	idHistorico INT PRIMARY KEY IDENTITY,
	idFuncionario INT FOREIGN KEY REFERENCES funcionarios(idFuncionario),
	idDia INT,
	ocorrido NVARCHAR(255) NOT NULL,
	quando DATETIME2 NOT NULL,
);