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
    /// Lógica de interacción para AddTransporte.xaml
    /// </summary>
    public partial class AddTransporte : Window
    {
        int ventaid;
        int subid;
        MedioTransporte m = new MedioTransporte();
        CTransporte control = new CTransporte();
        CSubasta controlsub = new CSubasta();
        Transporte t = new Transporte();
        public AddTransporte(int idsub, int idventa, string origen, string destino, MedioTransporte medio)
        {
            InitializeComponent();
            m = medio;
            Fecha.SelectedDate = DateTime.Today;
            Fecha.DisplayDate = DateTime.Today;
            MedioID.Text = medio.Medioid.ToString();
            Origen.Text = origen;
            Destino.Text = destino;
            ventaid = idventa;
            subid = idsub;
        }

        private void Comenzar_Click(object sender, RoutedEventArgs e)
        {
            t.Destino = Destino.Text;
            t.Origen = Origen.Text;
            t.Tipotransporte = TipoTransporte.Text;
            t.Transporteid = 0;
            t.Fechatransporte = Fecha.DisplayDate;
            t.Medioid = Convert.ToInt32(MedioID.Text);
            t.Estadotransporte = Estado.Text;
            
            if (control.InsertarTransporte(t, ventaid))
            {
                controlsub.FinalizarSubasta(subid, 1);
                this.Close();
            }
        }
    }
}
