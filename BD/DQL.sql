USE sistemaDePontos;

CREATE PROC horasTrabalhadasDoDia 
@id INT
AS SELECT 
	DATEDIFF(
		hour,
			(SELECT entrada FROM diasDeTrabalho WHERE idDia = @id),
			(SELECT saida FROM diasDeTrabalho WHERE idDia = @id)
		) AS horasTrabalhadas


CREATE PROC horasTrabalhadasDoMes
@mes INT
AS SELECT 
	DATEDIFF(
		hour,
			(SELECT MIN(saida) AS coluna
				FROM diasDeTrabalho	
				WHERE MONTH(saida) = @mes
			),
			(SELECT MAX(saida) AS coluna
				FROM diasDeTrabalho	
				WHERE MONTH(saida) = @mes
			)
		) AS horasTrabalhadas

