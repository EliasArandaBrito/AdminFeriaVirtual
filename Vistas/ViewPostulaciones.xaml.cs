using Controller;
using Models;
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
    /// Lógica de interacción para ViewPostulaciones.xaml
    /// </summary>
    public partial class ViewPostulaciones : Window
    {
        CPostulacion controller_post = new CPostulacion();
        CContrato controller_con = new CContrato();
        Contrato x = null;
        Postulacion z = null;
        public ViewPostulaciones()
        {
            InitializeComponent();
            salidacon.IsReadOnly = true;
            salidapost.IsReadOnly = true;
            salidapost.IsEnabled = false;
            salidacon.ItemsSource = controller_con.GetPublishedContratos();
            
        }

        private void salidacon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (salidacon.SelectedIndex != -1)
            {
                x = (Contrato)salidacon.SelectedItem;
            }
            salidapost.IsEnabled = true;
            salidapost.ItemsSource = controller_post.GetSelectedPostulacion(x.Contratoid);
        }

        private void salidapost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            z = (Postulacion)salidapost.SelectedItem;
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            if(x != null && z != null)
            {
                AddVenta addVenta = new AddVenta(x, z);
                addVenta.Show();
            }
            else MessageBox.Show("Para comenzar una venta, debe haber seleccionado el contrato y su respectiva postulación aprobada", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (z != null)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("¿Está seguro que desea deseleccionar esta postulación aprobada por el cliente?", "Advertencia", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    z.Selected = 0;
                    controller_post.ActualizarPostulacion(z);
                }
            }
            else MessageBox.Show("Para eliminar, primero debe seleccionar una postulación", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            salidapost.ItemsSource = controller_post.GetSelectedPostulacion(x.Contratoid);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            if (x != null)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("¿Está seguro que desea cancelar la publicación de este contrato?", "Advertencia", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    controller_con.PublicarContrato(x.Contratoid, 0);
                }
            }
            else MessageBox.Show("Para eliminar, primero debe seleccionar un contrato", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            salidapost.ItemsSource = controller_post.GetSelectedPostulacion(x.Contratoid);
        }
    }
}
