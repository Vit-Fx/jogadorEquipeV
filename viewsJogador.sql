-- View para listar Jogador e local de nascimento

CREATE VIEW vwJogNasc AS
	SELECT tbJogador.cdJog,
    tbJogador.nmJog,
	tbJogador.cdPosicao,
    tbJogador.ftJog,
    tbJogador.dsIdade,
    tbJogador.dtNascJog,
    tbLocalNascJogador.dsCidadeNascJog,
    tbLocalNascJogador.dsEstadoNascJog,
    tbLocalNascJogador.dsPaisNascJog
    FROM tbJogador INNER JOIN tbLocalNascJogador ON tbJogador.cdJog = tbLocalNascJogador.cdJog;
    
    
    