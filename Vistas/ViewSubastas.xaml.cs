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
    /// Lógica de interacción para ViewSubastas.xaml
    /// </summary>
    public partial class ViewSubastas : Window
    {
        Venta v = new Venta();
        MedioTransporte m = new MedioTransporte();
        Subasta_Medio sub = new Subasta_Medio();
        SuperSubasta s = new SuperSubasta();
        Productor p = new Productor();
        Cliente c = new Cliente();
        CMedioTransporte controlmedio = new CMedioTransporte();
        CSubasta controlsub = new CSubasta();
        CVenta controlventa = new CVenta();
        CSubusuario controluser = new CSubusuario();
        public ViewSubastas()
        {
            InitializeComponent();
            salidasub.IsReadOnly = true;
            salidamed.IsReadOnly = true;
            salidasub.ItemsSource = controlsub.GetSuperSubasta();
        }

        private void salidasub_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            s = (SuperSubasta)salidasub.SelectedItem;
            v = controlventa.GetVentaById(s.Ventaid);
            salidamed.ItemsSource = controlmedio.GetSubMedioBySub(s.Subastaid);
        }

        private void salidamed_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sub = (Subasta_Medio)salidamed.SelectedItem;
            m = controlmedio.GetMedioTransporteById(sub.Medioid);
            Id.Text = m.Medioid.ToString();
            patente.Text = m.Patente;
            ancho.Text = m.Ancho.ToString();
            alto.Text = m.Alto.ToString();
            largo.Text = m.Largo.ToString();
            capacidad.Text = m.Capacidad.ToString();
            string refrigeracion;
            switch (m.Refrigerado)
            {
                case 1:
                    refrigeracion = "Si";
                        break;
                case 0:
                    refrigeracion = "No";
                    break;
                default:
                    refrigeracion = "No";
                    break;
            }
            refri.Text = refrigeracion;
            precio.Text = m.Precio.ToString();
            transportista.Text = m.Transportistaid.ToString();

        }

        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            if(s!= null && m != null && v != null && v.Productorid != null && v.Clienteid != null)
            {
                if (m.Alto >= s.Alto_min && m.Ancho >= s.Ancho_min && m.Largo >= s.Largo_min && m.Capacidad >= m.Capacidad && m.Refrigerado == s.Refrigerado)
                {
                    int p_id = (int)v.Productorid;
                    int c_id = (int)v.Clienteid;
                    p = controluser.GetProductorById(p_id);
                    c = controluser.GetClienteById(c_id);
                    AddTransporte addTransporte = new AddTransporte(s.Subastaid, v.Ventaid, p.Direccion, c.Direccion, m);
                    addTransporte.Show();
                }
                else MessageBox.Show("Verifique que los requerimientos (tamaño, capacidad, refrigeración) sean cumplidos", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                
                
            }
            else MessageBox.Show("Verifique que haya una subasta y un medio válidos seleccionados", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            if (s != null)
            {
                controlsub.FinalizarSubasta(s.Subastaid, 1);
            }
            else MessageBox.Show("Verifique que haya una subasta válida seleccionada", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
