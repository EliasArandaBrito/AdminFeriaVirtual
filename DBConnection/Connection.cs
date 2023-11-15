using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;


namespace DBConnection
{
    public class Connection
    {

        public OracleConnection conexion = new OracleConnection("TNS_ADMIN=C:\\Users\\elias\\Oracle\\network\\admin;USER ID=ADMIN;PASSWORD=admin;DATA SOURCE=localhost:1521/XEPDB1;PERSIST SECURITY INFO=True;HA EVENTS=false;LOAD BALANCING=false");

        public DataTable EjecutarConsulta(OracleCommand cmd)
        {
            DataTable dt = new DataTable();
            try
            {
                OracleDataAdapter sda = new OracleDataAdapter(cmd);
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                dt = null;
                Console.Write(ex.Message);
            }
            return dt;
        }

    }
}
