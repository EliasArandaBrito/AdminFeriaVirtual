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
using System.Collections;
using System.Collections.Generic;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para ViewReports.xaml
    /// </summary>
    public partial class ViewReports : Window
    {
        Venta v = new Venta();
        CReports controller = new CReports();
        CVenta vc = new CVenta();
        public ViewReports()
        {
            InitializeComponent();
            salida.IsReadOnly = true;
            salida.DataContext = vc.GetAllVentas();
        }

        private void Externas_Click(object sender, RoutedEventArgs e)
        {
            salida.ItemsSource = vc.GetVentaByType("Venta Externa");
        }

        private void Todas_Click(object sender, RoutedEventArgs e)
        {
            salida.ItemsSource = vc.GetAllVentas();
        }

        private void Internas_Click(object sender, RoutedEventArgs e)
        {
            salida.ItemsSource = vc.GetVentaByType("Venta Interna");
            
        }

        private void Reporte_Click(object sender, RoutedEventArgs e)
        {
            controller.buildPDF(DataGridtoHTML(salida));
        }

        public StringBuilder DataGridtoHTML(DataGrid dg)
        {
            StringBuilder strB = new StringBuilder();
            //create html & table
            strB.AppendLine("<html><body><center><" +
                          "table border='1' cellpadding='0' cellspacing='0'>");
            strB.AppendLine("<tr>");
            //cteate table header
            for (int i = 0; i < dg.Columns.Count; i++)
            {
                strB.AppendLine("<td align='center' valign='middle'>" +
                               dg.Columns[i].Header + "</td>");
            }
            //create table body
            strB.AppendLine("<tr>");
            foreach (Venta i in dg.Items)
            {
                strB.AppendLine("<tr>");
                strB.AppendLine("<td align='center' valign='middle'>" + i.Ventaid.ToString() + "</td>");
                strB.AppendLine("<td align='center' valign='middle'>" + i.TipoVenta.ToString() + "</td>");
                strB.AppendLine("<td align='center' valign='middle'>" + i.Fechaventa.ToString() + "</td>");
                strB.AppendLine("<td align='center' valign='middle'>" + i.Totalventa.ToString() + "</td>");
                strB.AppendLine("<td align='center' valign='middle'>" + i.Estadoventaid.ToString() + "</td>");
                strB.AppendLine("<td align='center' valign='middle'>" + i.Transporteid.ToString() + "</td>");
                strB.AppendLine("<td align='center' valign='middle'>" + i.Productorid.ToString() + "</td>");
                strB.AppendLine("<td align='center' valign='middle'>" + i.Clienteid.ToString() + "</td>");
                strB.AppendLine("</tr>");

            }
            //table footer & end of html file
            strB.AppendLine("</table></center></body></html>");
            return strB;
        }

        public IEnumerable<DataGridRow> GetDataGridRows(DataGrid grid)
        {
            var itemsSource = grid.ItemsSource as IEnumerable;
            if (null == itemsSource) yield return null;
            foreach (var item in itemsSource)
            {
                var row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (null != row) yield return row;
            }
        }
    }
}
