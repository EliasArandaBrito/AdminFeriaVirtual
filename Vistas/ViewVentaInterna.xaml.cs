using Controller;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Lógica de interacción para ViewVentaInterna.xaml
    /// </summary>
    public partial class ViewVentaInterna : Window
    {
        CProducto controlpro = new CProducto();
        CVenta controller = new CVenta();
        Producto p = new Producto();
        Venta v = new Venta();
        CSubasta controlsub = new CSubasta();
        public ViewVentaInterna()
        {
            InitializeComponent();
            salida.IsReadOnly = true;
            salida.ItemsSource = controller.GetVentaByType("Venta Interna");
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            AddVentaInterna addVentaInterna = new AddVentaInterna();
            addVentaInterna.Show();
        }

        private void salida_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComenzarSubasta.IsEnabled = true;
            v = (Venta)salida.SelectedItem;
            if (v != null)
            {
                switch (v.Estadoventaid)
                {
                    case 3:
                        EstadoVenta.SelectedIndex = 0;
                        break;
                    case 0:
                        EstadoVenta.SelectedIndex = 1;
                        break;
                    case 2:
                        EstadoVenta.SelectedIndex = 2;
                        break;
                    case 1:
                        EstadoVenta.SelectedIndex = 3;
                        break;
                    case 4:
                        EstadoVenta.SelectedIndex = 4;
                        break;
                    default:
                        EstadoVenta.SelectedIndex = 0;
                        break;
                }
                Transportista.Text = v.Transporteid.ToString();
                List<Subasta> sub = controlsub.GetAllSubasta();
                foreach (Subasta s in sub)
                {
                    if (v.Ventaid == s.Ventaid)
                    {
                        ComenzarSubasta.IsEnabled = false;
                    }
                }
            }
        }

        private void CambiaEstado_Click(object sender, RoutedEventArgs e)
        {
            if (v != null)
            {
                int state = 0;
                switch (EstadoVenta.SelectedIndex)
                {
                    case 0:
                        state = 3;
                        break;
                    case 1:
                        state = 0;
                        break;
                    case 2:
                        state = 2;
                        break;
                    case 3:
                        state = 1;
                        break;
                    case 4:
                        state = 4;
                        break;
                    default:
                        break;
                }
                v.Estadoventaid = state;
                controller.EstadoVenta(v.Ventaid, state);

            }
            salida.ItemsSource = controller.GetVentaByType("Venta Interna");
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ComenzarSubasta_Click(object sender, RoutedEventArgs e)
        {
            if (v != null)
            {
                AddSubasta add = new AddSubasta(v);
                add.Show();
            }
        }
    }
}
