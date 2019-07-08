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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using PruebaBD.Connection;
using PruebaBD.Dao;
using PruebaBD.Vo;

namespace PruebaBD
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        loginOP op;
        
        

        public MainWindow()
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

        private void Btn_login_Click(object sender, RoutedEventArgs e)
        {
            List<Login> datos = op.Select();
           
            for (int i = 0; i < datos.Count; i++)
            { 
                if (datos[i].getUsername().Equals(txt_usuario.Text) && datos[i].getPassword().Equals(txt_password.Password))
                {
                    Turistico turist = new Turistico();
                    turist.Show();
                    this.Close();
                    return;

                }else if (!datos[i].getUsername().Equals(txt_usuario.Text) || !datos[i].getPassword().Equals(txt_password.Password))
                {
                    MessageBox.Show("Usuario o Password incorrectos.");
                    return;
                }
            }
            MessageBox.Show("Usuario o Password incorrectos.");
        }



        private void boton_registrar(object sender, RoutedEventArgs e)
        {
            register register = new register();
            register.Show();
            this.Close();
        }

        private void Btn_recuperar(object sender, RoutedEventArgs e)
        {
            ForgetPassword password = new ForgetPassword();
            password.Show();
            this.Close();

            
        }
    }
}
