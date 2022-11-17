using jogadorEquipeV.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;

namespace jogadorEquipeV.Dados
{
    public class acoesJogador
    {
        conexao cn = new conexao();

        public void cadJogador(modelJogador cm) 
        {

            MySqlCommand cmd = new MySqlCommand("Call spInsJog(@pNome, @pCdPosicao, @pFtJog, @pDsIdade, @pDtNascJog, @pDsCidadeNasc, @pDsEstadoNasc, @pDsPaisNasc)", cn.MyConectarBD());

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


        //public List<ModelJogador> GetJogador()
        //{
        //    List<ModelJogador> JogadorList = new List<ModelJogador>();

        //    MySqlCommand cmd = new MySqlCommand("select * from tbJogador", cn.MyConectarBD());
        //    MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();

        //    sd.Fill(dt);
        //    cn.MyDesconectarBD();

        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        JogadorList.Add(
        //            new ModelJogador
        //            {
        //                cdAni = Convert.ToString(dr["cdAni"]),
        //                nmAni = Convert.ToString(dr["nmAni"]),
        //                fotoAni = Convert.ToString(dr["fotoAni"]),
        //                cdCli = Convert.ToString(dr["cdCli"]),
        //            });
        //    }
        //    return JogadorList;
    }


}
