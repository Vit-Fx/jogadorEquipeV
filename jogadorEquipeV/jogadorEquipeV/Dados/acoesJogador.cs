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

            MySqlCommand cmd = new MySqlCommand("Call spInsJog(@nmJog, @cdPosicao, @ftJog, @dsIdade, @dtNascJog, @dsCidadeNasc, @dsEstadoNasc, @dsPaisNasc", cn.MyConectarBD());

            
            cmd.Parameters.Add("@nmJog", MySqlDbType.VarChar).Value = cm.nmJog;
            cmd.Parameters.Add("@cdPosicao", MySqlDbType.Int32).Value = cm.cdPosicao;
            cmd.Parameters.Add("@ftJog", MySqlDbType.VarChar).Value = cm.ftJog;
            cmd.Parameters.Add("@dsIdade", MySqlDbType.VarChar).Value = cm.dsIdade;
            cmd.Parameters.Add("@dtNascJog", MySqlDbType.Date).Value = cm.dtNascJog;
            cmd.Parameters.Add("@dsCidadeNasc", MySqlDbType.VarChar).Value = cm.dsCidadeNascJog;
            cmd.Parameters.Add("@dsEstadoNasc", MySqlDbType.VarChar).Value = cm.dsEstadoNascJog;
            cmd.Parameters.Add("@dsPaisNasc", MySqlDbType.VarChar).Value = cm.dsPaisNascJog;
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
                        cdPosicao = Convert.ToInt32(dr["cdPosicao"]),
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
