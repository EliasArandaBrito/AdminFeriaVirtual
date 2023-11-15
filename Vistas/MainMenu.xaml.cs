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
    /// Lógica de interacción para MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewContracts contracts = new ViewContracts();
            contracts.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ViewSubastas subastas = new ViewSubastas();
            subastas.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ViewPostulaciones ventaExterna = new ViewPostulaciones();
            ventaExterna.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ViewVentas ventaExterna = new ViewVentas();
            ventaExterna.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            ViewReports reports = new ViewReports();
            reports.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            ViewUsers users = new ViewUsers();
            users.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            ViewVentaInterna ventaInterna = new ViewVentaInterna();
            ventaInterna.Show();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            ViewTransportes viewTransportes = new ViewTransportes();
            viewTransportes.Show();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            ViewPagos viewPagos = new ViewPagos();
            viewPagos.Show();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
