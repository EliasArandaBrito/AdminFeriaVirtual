using Models;
using Controller;
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
    /// Lógica de interacción para AddVentaInterna.xaml
    /// </summary>
    public partial class AddVentaInterna : Window
    {
        CProducto controlpro = new CProducto();
        CVenta controlven = new CVenta();
        Producto p = new Producto();
        Venta v = new Venta();
        Venta_Producto vp = new Venta_Producto();
        public AddVentaInterna()
        {
            InitializeComponent();
            Salida.IsReadOnly = true;
            Salida.ItemsSource = controlpro.GetAllProductos();
            FechaVenta.SelectedDate = DateTime.Today;
            FechaVenta.DisplayDate = DateTime.Today;
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            int quantity;
            if (p != null && int.TryParse(Cantidad.Text, out quantity))
            {
                v.Totalventa = p.Precio * quantity;
                v.Productorid = Int32.Parse(Productor.Text);
                v.Fechaventa = FechaVenta.DisplayDate;
                v.TipoVenta = TipoVenta.Text;
                int estado;
                switch (EstadoVenta.Text)
                {
                    case "Aprobada":
                        estado = 1;
                        break;
                    case "Cancelada":
                        estado = 0;
                        break;
                    case "En Tránsito":
                        estado = 2;
                        break;
                    case "Completada":
                        estado = 3;
                        break;
                    default:
                        estado = 1;
                        break;
                }
                v.Estadoventaid = estado;

                
                if (controlven.InsertarVenta(v))
                {
                    vp.Productoid = p.Productoid;
                    vp.Ventaid = controlven.GetVentaSeq() - 1;
                    Console.WriteLine(vp.Ventaid);
                    vp.Cantidad = quantity;
                    if (controlven.InsertarVentaProducto(vp))
                    {
                        this.Close();
                    }

                }
                
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            p = (Producto)Salida.SelectedItem;
            Productor.Text = p.Productorid.ToString();
            Producto.Text = p.Productoid.ToString();
        }

        private void Cantidad_TextChanged(object sender, TextChangedEventArgs e)
        {
            int quantity;
            if(int.TryParse(Cantidad.Text, out quantity)){
                TotalVenta.Text = (quantity * p.Stock).ToString() ;
            }
        }
    }
}
