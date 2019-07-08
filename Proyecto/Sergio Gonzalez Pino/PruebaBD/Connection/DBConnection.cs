using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PruebaBD.Connection
{
    public class DBConnection
    {
        public MySqlConnection Conex = new MySqlConnection();
        static string serv = "Server=localhost;";
        static string db = "Database=login;";
        static string usuario = "UID=root;";
        static string pwd = "Password = pestillo;";

        string CadenaDeConexion = serv + db + usuario + pwd;
       

        public void Conectar()
        {
            try
            {
                Conex.ConnectionString = CadenaDeConexion;
                Conex.Open();

                
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
        public void Desconectar()
        {
            Conex.Close();
        }
    }
}
