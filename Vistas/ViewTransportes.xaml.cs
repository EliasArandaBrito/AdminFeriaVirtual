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
using Models;
using Controller;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para ViewTransportes.xaml
    /// </summary>
    public partial class ViewTransportes : Window
    {
        CTransporte control = new CTransporte();
        Transporte t = new Transporte();
        public ViewTransportes()
        {
            InitializeComponent();
            salida.IsReadOnly = true;
            salida.ItemsSource = control.GetAllTransporte();
        }

        private void Actualizar_Click(object sender, RoutedEventArgs e)
        {
            if(t != null)
            {
                t.Destino = Destino.Text;
                t.Origen = Origen.Text;
                t.Tipotransporte = TipoTransporte.Text;
                t.Fechatransporte = Fecha.DisplayDate;
                t.Medioid = Convert.ToInt32(MedioID.Text);
                t.Estadotransporte = Estado.Text;
                control.ActualizarTransporte(t);
            }
            salida.ItemsSource = control.GetAllTransporte();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            t = (Transporte)salida.SelectedItem;
            if(t != null)
            {
                Fecha.SelectedDate = t.Fechatransporte;
                Fecha.DisplayDate = t.Fechatransporte;
                Origen.Text = t.Origen;
                Destino.Text = t.Destino;
                MedioID.Text = t.Medioid.ToString();
                switch (t.Tipotransporte)
                {
                    case "Nacional":
                        TipoTransporte.SelectedIndex = 0;
                        break;
                    case "Internacional Terrestre":
                        TipoTransporte.SelectedIndex = 1;
                        break;
                    case "Internacional Híbrido":
                        TipoTransporte.SelectedIndex = 2;
                        break;
                    default:
                        TipoTransporte.SelectedIndex = 0;
                        break;
                }
                switch (t.Estadotransporte)
                {
                    case "En Preparación":
                        Estado.SelectedIndex = 0;
                        break;
                    case "Recogiendo Productos":
                        Estado.SelectedIndex = 1;
                        break;
                    case "Tránsito a Bodega":
                        Estado.SelectedIndex = 2;
                        break;
                    case "Transportando a Destino":
                        Estado.SelectedIndex = 3;
                        break;
                    case "Entregado":
                        Estado.SelectedIndex = 4;
                        break;
                    case "Completado":
                        Estado.SelectedIndex = 5;
                        break;
                    default:
                        Estado.SelectedIndex = 0;
                        break;
                }
            }
            
        }
    }
}
