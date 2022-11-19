CREATE DATABASE bdJogadorEquipeV;

USE bdJogadorEquipeV;

CREATE TABLE tbPosicao(
	cdPosicao INT PRIMARY KEY AUTO_INCREMENT,
    dsPosicao VARCHAR(100)
);

CREATE TABLE tbJogador(
	cdJog INT PRIMARY KEY AUTO_INCREMENT,
    nmJog VARCHAR(80),
    cdPosicao INT,
    ftJog VARCHAR(255),
    dsIdade VARCHAR(3),
    dtNascJog VARCHAR(20),
    CONSTRAINT FOREIGN KEY (cdPosicao) REFERENCES tbPosicao(cdPosicao)
);

CREATE TABLE tbLocalNascJogador(
	cdLocalNasc INT PRIMARY KEY AUTO_INCREMENT,
	dsCidadeNascJog VARCHAR(80),
    dsEstadoNascJog VARCHAR(80),
    dsPaisNascJog VARCHAR(80),
    cdJog INT,
	CONSTRAINT FOREIGN KEY(cdJog) REFERENCES tbJogador(cdJog)
);

CREATE TABLE tbEquipe(
	cdEquipe INT PRIMARY KEY AUTO_INCREMENT, 
    nmEquipe VARCHAR(80),
    dsLocalEquipe VARCHAR(100)
);

CREATE TABLE tbEquipeJogador(
	cdEquipeJog INT PRIMARY KEY AUTO_INCREMENT,
    cdEquipe INT,
    cdJog INT,
    CONSTRAINT FOREIGN KEY(cdEquipe) REFERENCES tbEquipe(cdEquipe),
    CONSTRAINT FOREIGN KEY(cdJog) REFERENCES tbJogador(cdJog)
    );


    