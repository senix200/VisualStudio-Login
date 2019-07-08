using PruebaBD.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaBD.Vo
{
    public class Login
    {
        
        private String username;
        private String password;
        private String nombre;
        private String apellidos;
        private int edad;
        private String genero;
        private String correo;

        public string getUsername() { return this.username;}
        public string getPassword() { return this.password; }
        public string getNombre() { return this.nombre; }
        public string getApellidos() { return this.apellidos; }
        public int getEdad() { return this.edad; }
        public string getGenero() { return this.genero; }
        public string getCorreo() { return this.correo; }
  


        public void setUsername(string username)
        {
            this.username = username;
        }
        public void setPassword(string password)
        {
            this.password = password;
        }
        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }
        public void setApellidos(string apellidos)
        {
            this.apellidos = apellidos;
        }
        public void setEdad(int edad)
        {
            this.edad = edad;
        }
        public void setGenero(string genero)
        {
            this.genero = genero;
        }
        public void setCorreo(string correo)
        {
            this.correo = correo;
        }
        public Login(string username, string password, string nombre, string apellidos, int edad, string genero, string correo)
        {
            this.username = username;
            this.password = password;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.edad = edad;
            this.genero = genero;
            this.correo = correo;
        }
        

    }
}
