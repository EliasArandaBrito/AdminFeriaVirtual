using IronPdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Controller
{
    public class CReports
    {

        

        public PdfDocument buildPDF(StringBuilder html)
        {
            ChromePdfRenderer renderer = new ChromePdfRenderer();
            PdfDocument pdf = renderer.RenderHtmlAsPdf(html.ToString());
            pdf.SaveAs("C:\\Users\\elias\\Downloads\\Reporte.pdf");
            return pdf;
        }

        


    }
}
