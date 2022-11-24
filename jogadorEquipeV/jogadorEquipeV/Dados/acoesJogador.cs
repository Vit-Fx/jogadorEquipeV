using jogadorEquipeV.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;

namespace jogadorEquipeV.Dados
{
    public class acoesJogador
    {
        conexao cn = new conexao();

        public void cadJogador(modelJogador cm)
        {

            MySqlCommand cmd = new MySqlCommand("Call spInsJog(@pNome, @pCdPosicao, @pFtJog, @pDsIdade," +
                " @pDtNascJog, @pDsCidadeNasc, @pDsEstadoNasc, @pDsPaisNasc)", cn.MyConectarBD());

            cmd.Parameters.Add("@pNome", MySqlDbType.VarChar).Value = cm.nmJog;
            cmd.Parameters.Add("@pCdPosicao", MySqlDbType.VarChar).Value = cm.cdPosicao;
            cmd.Parameters.Add("@pFtJog", MySqlDbType.VarChar).Value = cm.ftJog;
            cmd.Parameters.Add("@pDsIdade", MySqlDbType.VarChar).Value = cm.dsIdade;
            cmd.Parameters.Add("@pDtNascJog", MySqlDbType.VarChar).Value = cm.dtNascJog;
            cmd.Parameters.Add("@pDsCidadeNasc", MySqlDbType.VarChar).Value = cm.dsCidadeNascJog;
            cmd.Parameters.Add("@pDsEstadoNasc", MySqlDbType.VarChar).Value = cm.dsEstadoNascJog;
            cmd.Parameters.Add("@pDsPaisNasc", MySqlDbType.VarChar).Value = cm.dsPaisNascJog;
            cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();

        }
        
        public void atualizaJogadorSemFoto(modelJogador cm)
        {
            MySqlCommand cmd = new MySqlCommand("update tbJogador set ftJog=@ftJog where cdJog=@cdJog)", cn.MyConectarBD());

            cmd.Parameters.Add("@cdJog", MySqlDbType.VarChar).Value = cm.cdJog;
            cmd.Parameters.Add("@ftJog", MySqlDbType.VarChar).Value = cm.ftJog;
        }

        public bool editJogador(modelJogador cm)
        {

            MySqlCommand cmd = new MySqlCommand("Call spEditJog(@pNome, @pCdPosicao, @pFtJog, @DsIdade," +
                " @pDtNascJog, @pDsCidadeNasc, @pDsEstadoNasc, pDsPaisNasc)", cn.MyConectarBD());

            cmd.Parameters.Add("pNome", MySqlDbType.VarChar).Value = cm.nmJog;
            cmd.Parameters.Add("@pCdPosicao", MySqlDbType.VarChar).Value = cm.cdPosicao;
            cmd.Parameters.Add("@pFtJog", MySqlDbType.VarChar).Value = cm.ftJog;
            cmd.Parameters.Add("@pDsIdade", MySqlDbType.VarChar).Value = cm.dsIdade;
            cmd.Parameters.Add("@pDtNascJog", MySqlDbType.VarChar).Value = cm.dtNascJog;
            cmd.Parameters.Add("@pDsCidadeNasc", MySqlDbType.VarChar).Value = cm.dsCidadeNascJog;
            cmd.Parameters.Add("@pDsEstadoNasc", MySqlDbType.VarChar).Value = cm.dsEstadoNascJog;
            cmd.Parameters.Add("@pDsPaisNasc", MySqlDbType.VarChar).Value = cm.dsPaisNascJog;

            int i = cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;

        }

        public void CarregaTodosJogadores()
        {

            List<SelectListItem> jogadores = new List<SelectListItem>();

            MySqlCommand cmd = new MySqlCommand("Select * from tbJogador", cn.MyConectarBD());
            MySqlDataReader rdr = cmd.ExecuteReader();

            cn.MyDesconectarBD();
        }

        public List<modelJogador> GetPosicao()
        {
            List<modelJogador> PosicaoList = new List<modelJogador>();

            MySqlCommand cmd = new MySqlCommand("select * from tbPosicao", cn.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            cn.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                PosicaoList.Add(
                    new modelJogador
                    {
                        cdPosicao = Convert.ToString(dr["cdPosicao"]),
                        dsPosicao = Convert.ToString(dr["dsPosicao"])
                    });
            }
            return PosicaoList;
        }


        public List<modelJogador> GetJogador()
        {
            List<modelJogador> JogadorList = new List<modelJogador>();

            MySqlCommand cmd = new MySqlCommand("select * from vwJogNasc", cn.MyConectarBD());
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            cn.MyDesconectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                JogadorList.Add(
                    new modelJogador
                    {
                        cdJog = Convert.ToString(dr["cdJog"]),
                        nmJog = Convert.ToString(dr["nmJog"]),
                        cdPosicao = Convert.ToString(dr["cdPosicao"]),
                        ftJog = Convert.ToString(dr["ftJog"]),
                        dsIdade = Convert.ToString(dr["dsIdade"]),
                        dtNascJog = Convert.ToString(dr["dtNascJog"]),
                        dsCidadeNascJog = Convert.ToString(dr["dsCidadeNascJog"]),
                        dsEstadoNascJog = Convert.ToString(dr["dsEstadoNascJog"]),
                        dsPaisNascJog = Convert.ToString(dr["dsPaisNascJog"]),
                    });
            }
            return JogadorList;
        }

        public bool DeletarJogador(int id) {

            MySqlCommand cmd = new MySqlCommand("Call deletarJog(@id)", cn.MyConectarBD());

            cmd.Parameters.AddWithValue("@id", id);

            int i = cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();

            if (i >= 1)
                return true;
            else
                return false;
        }

    }
}
