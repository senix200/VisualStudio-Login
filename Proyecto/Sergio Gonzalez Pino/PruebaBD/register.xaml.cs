using PruebaBD.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PruebaBD
{
    /// <summary>
    /// Lógica de interacción para register.xaml
    /// </summary>
    public partial class register : Window
    {
        loginOP op;

       
        public register()
        {
            InitializeComponent();
            op = new loginOP();
            
        }
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_register_Click(object sender, RoutedEventArgs e)
        {
            
            List<String> errores = new List<String>();
             if (txt_usuario.Text.Equals(""))
            {
                errores.Add("Usuario");
            }if (txt_password.Password.Equals("") )
            {
                errores.Add("Password");
            }
            if (txt_name.Text.Equals(""))
            {
                errores.Add("Nombre");
            }
            if (txt_lastname.Text.Equals(""))
            {
                errores.Add("Apellidos");
            }
            if (txt_age.Text.Equals(""))
            {
                errores.Add("Edad");
            }
            if (txt_gen.Text.Equals(""))
            {
                errores.Add("Genero");
            }
            if (txt_mail.Text.Equals(""))
            {
                errores.Add("Correo");
            }


            if (check_accept.IsChecked.Value && errores.Count == 0)
            {
                try
                {
                    String username = txt_usuario.Text;
                    String password = txt_password.Password;
                    String nombre = txt_name.Text;
                    String apellidos = txt_lastname.Text;
                    int edad = Convert.ToInt32(txt_age.Text);
                    String genero = txt_gen.Text;
                    String correo = txt_mail.Text;


                    op.insertar(username, password, nombre, apellidos, edad, genero, correo);

                    MainWindow main = new MainWindow();
                    main.Show();
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Debes introducir numeros en al campo de Edad");
                    
                }
                
               

            }

            else if (check_accept.IsChecked.Value && errores.Count != 0)
            {
                String error = "";
                for (int i = 0; i < errores.Count; i++)
                {
                    if (i == errores.Count - 1)
                    {
                        error += errores[i];
                    }
                    else
                    {
                        error += errores[i] + ", ";
                    }

                }
                MessageBox.Show("Debes rellenar los campos " + error);
                
            }
            else
            {
                MessageBox.Show("Debes aceptar las condiciones.");
            }
        }
            
                


            
        

        private void Btn_atras_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            login.Show();
            this.Close();
        }

    }
}
