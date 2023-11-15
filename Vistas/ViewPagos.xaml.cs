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
    /// Lógica de interacción para ViewPagos.xaml
    /// </summary>
    public partial class ViewPagos : Window
    {
        Pago p = new Pago();
        CPago control = new CPago();
        public ViewPagos()
        {
            InitializeComponent();
            salida.IsReadOnly = true;
            salida.ItemsSource = control.GetAllPagos();
        }

        private void Actualizar_Click(object sender, RoutedEventArgs e)
        {
            float pagado;
            if(p != null && Single.TryParse(total.Text, out pagado))
            {
                p.Fechapago = fechapago.DisplayDate;
                p._pago = pagado;
                control.UpdatePago(p);
            }
        }

        private void salida_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            p = (Pago)salida.SelectedItem;
            idpago.Text = p.Pagoid.ToString();
            fechapago.SelectedDate = p.Fechapago;
            fechapago.DisplayDate = p.Fechapago;
            idventa.Text = p.Ventaid.ToString();
            idusuario.Text = p.Usuarioid.ToString();
            total.Text = p._pago.ToString();
        }
    }
}
