-- PROC DE INSERIR

DELIMITER $$
DROP PROCEDURE IF EXISTS spInsJog;
CREATE PROCEDURE spInsJog(
    pNome VARCHAR(80),
    pCdPosicao INT,
    pFtJog VARCHAR(255),
    pDsIdade VARCHAR(3),
    pDtNascJog VARCHAR(20),
    pDsCidadeNasc VARCHAR(80),
    pDsEstadoNasc VARCHAR(80),
    pDsPaisNasc VARCHAR(80)
)
BEGIN
        DECLARE pCd INT;
        INSERT INTO tbjogador(
            nmJog,
            cdPosicao,
            ftJog,
            dsIdade,
            dtNascJog)
        VALUES(
            pNome,
            pCdPosicao,
            pFtJog,
            pDsIdade,
            pDtNascJog
        );
        SET pCd = LAST_INSERT_ID();
        INSERT INTO tblocalnascjogador(
            dsCidadeNascJog,
            dsEstadoNascJog,
            dsPaisNascJog,
            cdJog)
        VALUES(
            pDsCidadeNasc,
            pDsEstadoNasc,
            pDspaisNasc,
            pCd);
    END$$
DELIMITER ;
      
desc tblocalnascjogador;

-- PROC DE EDITAR

DROP PROCEDURE IF EXISTS spEditJog;
DELIMITER $$
	CREATE PROCEDURE spEditJog(
		pNome VARCHAR(80),
		pCdPosicao INT,
		pFtJog VARCHAR(255),
		pDsIdade VARCHAR(3),
		pDtNascJog VARCHAR(20),
		pDsCidadeNasc VARCHAR(80),
		pDsEstadoNasc VARCHAR(80),
		pDsPaisNasc VARCHAR(80)
    )
    BEGIN
		DECLARE pCd INT;
        DECLARE erro_sql TINYINT DEFAULT FALSE;
        DECLARE CONTINUE HANDLER FOR SQLEXCEPTION SET erro_sql = TRUE;
		
        START TRANSACTION;
        
        UPDATE tbJogador SET
        nmJog = pNome, 
        cdPosicao = pCdPosicao, 
        ftJog = pFtJog, 
        dsIdade = pDsIdade, 
        dtNascJog = pDtNascJog 
        WHERE cdJog = pCd;
        
        UPDATE tblocalnascjogador SET
        dsCidadeNascJog = pDsCidadeNasc,
        dsEstadoNascJog = pDsEstadoNasc,
        dsPaisNascJog = pDsPaisNasc 
        WHERE cdJog = pCd;
	
		IF(erro_sql = FALSE) THEN
			COMMIT;
		ELSE 
			ROLLBACK;
		END IF;
	END $$
DELIMITER ;
  