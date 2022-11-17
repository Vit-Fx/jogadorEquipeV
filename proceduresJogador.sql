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

select * from tblocalnascjogador;
Call spInsJog('Joao',1,'cai','12','2020-02-12','Itapevi','Sao Paulo','Brasil');
