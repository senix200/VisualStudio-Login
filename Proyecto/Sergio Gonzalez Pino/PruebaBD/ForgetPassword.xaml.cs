using PruebaBD.Dao;
using PruebaBD.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
    /// Lógica de interacción para ForgetPassword.xaml
    /// </summary>
    public partial class ForgetPassword : Window
    {
        loginOP op;

        public ForgetPassword()
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

        private void Btn_recuperar_Click(object sender, RoutedEventArgs e)
        {

            List<Login> datos = op.Select();

            for (int i = 0; i < datos.Count; i++)
            {
                if (datos[i].getUsername().Equals(txt_usuario.Text))
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                    
                    mail.From = new MailAddress("desarrollointerfaces1819@gmail.com");
                    mail.To.Add(datos[i].getCorreo());
                    mail.Subject = "Servicio de Recuperacion de contraseña";
                    mail.Body = "Hola "+datos[i].getNombre()+"\n" +"Aqui tienes tu contraseña del Usuario: "+txt_usuario.Text +" Password: "+datos[i].getPassword();

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("desarrollointerfaces1819@gmail.com", "interfaces1819");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
                    MessageBox.Show("Email enviado correctamente a " +datos[i].getCorreo());
                    return;

                }else if (!datos[i].getUsername().Equals(txt_usuario.Text))
                {
                    MessageBox.Show("Usuario no existe.");
                    return;
                }
            }
            MessageBox.Show("Usuario no existe.");

        }

        private void Btn_atras_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            login.Show();
            this.Close();
        }
    }
}
