using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;


using PruebaBD.Connection;
using System.Windows;
using PruebaBD.Vo;
using System.Net.Mail;
using System.Net;

namespace PruebaBD.Dao
{
    public class loginOP
    {

        DBConnection db = new DBConnection();
        MySqlCommand comando = new MySqlCommand();
   
        
        
        public void insertar(String username, String password, String nombre, String apellidos, int edad, String genero, String correo)
        {


            String sql = "Insert into login values('" + username + "','" + password + "','" + nombre + "', '" + apellidos + "'," + edad + ", '" + genero + "', '" + correo + "'" + ")";

            try
            {

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql;
                comando.Connection = db.Conex;

                db.Conectar();
                comando.ExecuteNonQuery();
                db.Desconectar();
                MessageBox.Show("Registro insertado con éxito");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Usuario duplicado");
            }

        }

        

        public List<Login> Select()
        {
            List<Login> logins = new List<Login>();
            DBConnection db = new DBConnection();
            String sql = "Select * from login";
            Login a;
            try
            {
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql;
                comando.Connection = db.Conex;
                db.Conectar();
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    String username = reader["Username"].ToString();
                    String password = reader["Password"].ToString();
                    String nombre = reader["Nombre"].ToString();
                    String apellidos = reader["Apellidos"].ToString();
                    int age = Int32.Parse(reader["Edad"].ToString());
                    String genero = reader["Genero"].ToString();
                    String correo = reader["Correo"].ToString();
                    a = new Login(username, password, nombre, apellidos, age, genero, correo);
                    logins.Add(a);

                }

                db.Desconectar();
                return logins;
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return logins;

        }
    }
}

        
        
