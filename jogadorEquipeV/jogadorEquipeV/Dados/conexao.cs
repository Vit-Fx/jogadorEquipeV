using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace jogadorEquipeV.Dados
{
    public class conexao
    {
        MySqlConnection cn = new MySqlConnection("Server=localhost; Database=bdjogadorequipev; User=root; Password =12345678");
        public static string msg;

        public MySqlConnection MyConectarBD()
        {
            try
            {
                cn.Open();
            }
            catch (Exception erro)
            {
                msg = "Ocorreu um erro ao encontrar o servidor" + erro.Message;
            }

            return cn;
        }

        public MySqlConnection MyDesconectarBD()
        {

            try
            {
                cn.Close();

            }
            catch (Exception erro)
            {
                msg = "Ocorreu um erro ao encontrar o servidor" + erro.Message;
            }
            return cn;
        }

    }
}







