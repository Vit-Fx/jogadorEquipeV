using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace jogadorEquipeV.Models
{
    public class modelJogador
    {
        public int cdJog { get; set; }

        [DisplayName("Nome do Jogador")]
        public string nmJog { get; set; }

        [DisplayName("Foto")]
        public string ftJog { get; set; }

        [DisplayName("Idade")]
        public string dsIdade { get; set; }

        [DisplayName("Data de Nascimento")]
        public DateTime dtNascJog { get; set; }
        public int cdLocalNascJogador { get; set; }

        [DisplayName("Cidade de Nascimento")]
        public string dsCidadeNascJog { get; set; }

        [DisplayName("Estado de Nascimento")]
        public string dsEstadoNascJog { get; set; }

        [DisplayName("País de Nascimento")]
        public string dsPaisNascJog { get; set; }

        public int cdPosicao { get; set; }
        public string dsPosicao { get; set; }
    }
}