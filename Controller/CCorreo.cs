using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class CCorreo
    {
        SmtpClient client = new SmtpClient("live.smtp.mailtrap.io", 587)
        {
            Credentials = new NetworkCredential("api", "dab30c31d2ccf1c5e5922b44f10d9623"),
            EnableSsl = true
        };


        public bool SendMail(string recipient, string subject, string body)
        {
            try
            {
                client.Send("mailtrap@feriavirtualmaipo.shop", recipient, subject, body);
                Console.WriteLine("Sent");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }   
        }
        
    }
}
