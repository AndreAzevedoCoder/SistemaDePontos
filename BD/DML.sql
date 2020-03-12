USE sistemaDePontos;

SELECT * FROM funcionarios;
SELECT * FROM diasDeTrabalho;

INSERT INTO funcionarios(nome,nickname,senha)
VALUES('André Azevedo','Andre','123456');

INSERT INTO diasDeTrabalho(enderecoIP,idFuncionario,entrada,saida)
VALUES('255.255.255.255',1,'15/04/2020','15/06/2020');


INSERT INTO diasDeTrabalho(enderecoIP,idFuncionario,entrada,saida)
VALUES('255.255.255.255',1,'15/07/2020','15/08/2020');