using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnection;
using Models;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;

namespace Controller
{
    public class CPago
    {
        OracleCommand Comando = new OracleCommand();

        public List<Pago> GetAllPagos()
        {
            List<Pago> pagos = new List<Pago>();
            Connection Cnn = new Connection();
            using (Cnn.conexion)
            {
                try
                {
                    Cnn.conexion.Open();

                    using (OracleCommand command = new OracleCommand("BEGIN :cursor := get_all_pagos; END;", Cnn.conexion))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("cursor", OracleDbType.RefCursor, ParameterDirection.ReturnValue);

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Pago pago = new Pago
                                {
                                    Pagoid = Convert.ToInt32(reader["Pagoid"]),
                                    Fechapago = Convert.ToDateTime(reader["Fecha_Pago"]),
                                    Usuarioid = Convert.ToInt32(reader["Usuarioid"]),
                                    Ventaid = Convert.ToInt32(reader["Ventaid"]),
                                    _pago = Convert.ToSingle(reader["Pago"])
                                };

                                pagos.Add(pago);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            return pagos;
        }

        public Pago GetPagoById(int pagoId)
        {
            Pago pago = null;
            Connection Cnn = new Connection();
            using (Cnn.conexion)
            {
                try
                {
                    Cnn.conexion.Open();

                    using (OracleCommand command = new OracleCommand("BEGIN :cursor := get_pago_by_id(:id); END;", Cnn.conexion))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("cursor", OracleDbType.RefCursor, ParameterDirection.ReturnValue);
                        command.Parameters.Add("id", OracleDbType.Int32, pagoId, ParameterDirection.Input);

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                pago = new Pago
                                {
                                    // Populate Pago properties here
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            return pago;
        }

        public bool InsertPago(Pago pago)
        {
            try
            {
                Connection Cnn = new Connection();
                Comando.Connection = Cnn.conexion;
                Comando.CommandText = "insert_pago"; // Replace with the actual stored procedure name
                Comando.CommandType = CommandType.StoredProcedure;
                Cnn.conexion.Open();

                // Add parameters based on the Pago properties
                Comando.Parameters.Add(new OracleParameter("p_fecha_pago", OracleDbType.Date) { Value = pago.Fechapago });
                Comando.Parameters.Add(new OracleParameter("p_pago", OracleDbType.Decimal) { Value = pago._pago });
                Comando.Parameters.Add(new OracleParameter("p_ventaid", OracleDbType.Int32) { Value = pago.Ventaid });
                Comando.Parameters.Add(new OracleParameter("p_usuarioid", OracleDbType.Int32) { Value = pago.Usuarioid });

                Comando.ExecuteNonQuery();
                Comando.Parameters.Clear();
                Cnn.conexion.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdatePago(Pago pago)
        {
            try
            {
                Connection Cnn = new Connection();
                Comando.Connection = Cnn.conexion;
                Comando.CommandText = "update_pago"; // Replace with the actual stored procedure name
                Comando.CommandType = CommandType.StoredProcedure;
                Cnn.conexion.Open();

                // Add parameters based on the Pago properties
                Comando.Parameters.Add(new OracleParameter("p_pagoid", OracleDbType.Int32) { Value = pago.Pagoid });
                Comando.Parameters.Add(new OracleParameter("p_fecha_pago", OracleDbType.Date) { Value = pago.Fechapago });
                Comando.Parameters.Add(new OracleParameter("p_pago", OracleDbType.Decimal) { Value = pago._pago });
                Comando.Parameters.Add(new OracleParameter("p_ventaid", OracleDbType.Int32) { Value = pago.Ventaid });
                Comando.Parameters.Add(new OracleParameter("p_usuarioid", OracleDbType.Int32) { Value = pago.Usuarioid });

                Comando.ExecuteNonQuery();
                Comando.Parameters.Clear();
                Cnn.conexion.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeletePago(int pagoId)
        {
            try
            {
                Connection Cnn = new Connection();
                Comando.Connection = Cnn.conexion;
                Comando.CommandText = "delete_pago"; // Replace with the actual stored procedure name
                Comando.CommandType = CommandType.StoredProcedure;
                Cnn.conexion.Open();

                // Add the parameter for Pago ID
                Comando.Parameters.Add(new OracleParameter("p_pagoid", OracleDbType.Int32) { Value = pagoId });

                Comando.ExecuteNonQuery();
                Comando.Parameters.Clear();
                Cnn.conexion.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
