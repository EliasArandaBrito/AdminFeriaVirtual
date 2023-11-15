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
using Controller;
using Models;
using System.Text.RegularExpressions;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para AddVenta.xaml
    /// </summary>
    public partial class AddVenta : Window
    {
        CVenta controller = new CVenta();
        CSubusuario controlsub = new CSubusuario();
        Contrato contrato = new Contrato();
        Postulacion postulacion = new Postulacion();
        CCorreo correo = new CCorreo();
        string correocliente;
        string productorcorreo;
        public AddVenta(Contrato c, Postulacion p)
        {
            InitializeComponent();
            Cliente.Text = c.Usuarioid.ToString();
            Productor.Text = p.Productorid.ToString();
            TotalVenta.Text = (p.Precio * c.Cantidad).ToString();
            FechaVenta.SelectedDate = DateTime.Today;
            FechaVenta.DisplayDate = DateTime.Today;
            contrato = c;
            postulacion = p;
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {

            int estado = 1;
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
            Venta v = new Venta
            {
                Clienteid = contrato.Usuarioid,
                Productorid = postulacion.Productorid,
                Fechaventa = FechaVenta.DisplayDate,
                Estadoventaid = estado,
                TipoVenta = TipoVenta.Text,
                Transporteid = null,
                Ventaid = 0,
                Totalventa = Convert.ToDouble(TotalVenta.Text)
            };

            try
            {
                correocliente = controlsub.GetClienteById((int)v.Clienteid).Correo;
                productorcorreo = controlsub.GetProductorById((int)v.Productorid).Correo;
                controller.InsertarVenta(v);
                correo.SendMail(correocliente, "Venta Confirmada", "Se le informa que su venta se encuentra activa");
                correo.SendMail(productorcorreo, "Venta Confirmada", "Se le informa que su venta se encuentra activa");
                this.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
