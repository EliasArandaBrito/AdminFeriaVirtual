using Controller;
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

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Username.Text != "" && Password.Password != "")
            {
                Console.WriteLine(Username.Text);
                Console.WriteLine(Password.Password);
                CUsuario usuario = new CUsuario();
                int loginStatus = usuario.LoginCheckTipo(Username.Text, Password.Password, 3);
                int loginStatusCon = usuario.LoginCheckTipo(Username.Text, Password.Password, 6);
                bool isconsultor = false;

                switch (loginStatusCon)
                {
                    case -1:
                        MessageBox.Show("Login denegado. Verifique Usuario y Contraseña", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    case -2:
                        isconsultor = false;
                        break;
                    case -3:
                        MessageBox.Show("Error no identificado, corregir código", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    case 0:
                        ViewReports reports = new ViewReports();
                        reports.Show();
                        isconsultor = true;
                        break;
                    default:
                        // Handle any other cases here
                    
                        break;
                }
                if (!isconsultor)
                {
                    switch (loginStatus)
                    {
                        case -1:
                            MessageBox.Show("Login denegado. Verifique Usuario y Contraseña", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                            break;
                        case -2:
                            MessageBox.Show("Login denegado. Usuario no autorizado", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                            break;
                        case -3:
                            MessageBox.Show("Error no identificado, corregir código", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                            break;
                        case 0:
                            MainMenu menu = new MainMenu();
                            menu.Show();
                            break;
                        default:
                            // Handle any other cases here
                            break;
                    }
                }
                
            }
           
        }
    }
}
