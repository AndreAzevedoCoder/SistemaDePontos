CREATE DATABASE sistemaDePontos;
USE sistemaDePontos

CREATE TABLE funcionarios (
	idFuncionario INT PRIMARY KEY IDENTITY,
	nome TEXT,
	nickname TEXT,
	senha TEXT,
);

CREATE TABLE diasDeTrabalho (
	idDia INT PRIMARY KEY IDENTITY,
	enderecoIP TEXT,
	idFuncionario INT FOREIGN KEY REFERENCES funcionarios(idFuncionario),
	entrada DATETIME2,
	intervaloEntrada DATETIME2,
	intervaloSaida DATETIME2,
	saida DATETIME2,
);
