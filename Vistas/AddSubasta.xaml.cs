using Models;
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
    /// Lógica de interacción para AddSubasta.xaml
    /// </summary>
    public partial class AddSubasta : Window
    {
        Subasta s = new Subasta();
        Venta v = new Venta();
        CSubasta controller = new CSubasta();
        public AddSubasta(Venta venta)
        {
            InitializeComponent();
            v = venta;
            idventa.Text = venta.Ventaid.ToString();
            fechain.SelectedDate = DateTime.Today;
            fechain.DisplayDate = DateTime.Today;
            fechafin.SelectedDate = DateTime.Today.AddDays(1);
            fechafin.DisplayDate = DateTime.Today.AddDays(1);
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            float dummy;
            if (Single.TryParse(Largo.Text, out dummy) && Single.TryParse(Ancho.Text, out dummy)  && Single.TryParse(Alto.Text, out dummy) && Single.TryParse(Capacidad.Text, out dummy) && Refrigerado.IsChecked != null)
            {
                int refri;
                if ((bool)(Refrigerado.IsChecked = true)) { refri = 1; }
                else { refri = 0; }
                s.Ventaid = v.Ventaid;
                s.Subastaid = 0;
                s.Finished = 0;
                s.Fechainicio = DateTime.Today;
                s.Fechatermino = fechafin.DisplayDate;
                s.Largo_min = Single.Parse(Largo.Text);
                s.Alto_min = Single.Parse(Alto.Text);
                s.Ancho_min = Single.Parse(Ancho.Text);
                s.Capacidad = Single.Parse(Capacidad.Text);
                s.Refrigerado = refri;
                
                if (controller.InsertarSubasta(s)) {
                    this.Close();
                }

            }
            else MessageBox.Show("Verifique que alto, ancho y/o largo mínimos posean valores numéricos válidos", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
