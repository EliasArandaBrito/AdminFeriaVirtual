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
    public class CVenta
    {
        OracleCommand Comando = new OracleCommand();

        public bool InsertarVenta(Venta c)
        {
            try
            {
                Connection Cnn = new Connection();
                Comando.Connection = Cnn.conexion;
                Comando.CommandText = "insert_venta";
                Comando.CommandType = CommandType.StoredProcedure;
                Cnn.conexion.Open();
                Comando.Parameters.Add(new OracleParameter("p_fechaventa", OracleDbType.Date) { Value = c.Fechaventa });
                Comando.Parameters.Add(new OracleParameter("p_tipoventa", OracleDbType.Varchar2) { Value = c.TipoVenta });
                Comando.Parameters.Add(new OracleParameter("p_totalventa", OracleDbType.Decimal) { Value = c.Totalventa });
                Comando.Parameters.Add(new OracleParameter("p_estadoventaid", OracleDbType.Int32) { Value = c.Estadoventaid });
                Comando.Parameters.Add(new OracleParameter("p_transporteid", OracleDbType.Int32) { Value = c.Transporteid });
                Comando.Parameters.Add(new OracleParameter("p_productorid", OracleDbType.Int32) { Value = c.Productorid });
                Comando.Parameters.Add(new OracleParameter("p_clienteid", OracleDbType.Int32) { Value = c.Clienteid });
                Comando.ExecuteNonQuery();
                Comando.Parameters.Clear();
                Cnn.conexion.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public List<Venta> GetAllVentas()
        {
            List<Venta> ventaList = new List<Venta>();
            Connection Cnn = new Connection();
            using (Cnn.conexion)
            {
                try
                {
                    Cnn.conexion.Open();

                    using (OracleCommand command = new OracleCommand("BEGIN :cursor := get_all_ventas; END;", Cnn.conexion))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("cursor", OracleDbType.RefCursor, ParameterDirection.ReturnValue);

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Venta venta = new Venta
                                {
                                    Ventaid = Convert.ToInt32(reader["VentaId"]),
                                    TipoVenta = reader["TipoVenta"].ToString(),
                                    Fechaventa = Convert.ToDateTime(reader["FechaVenta"]),
                                    Totalventa = Convert.ToDouble(reader["TotalVenta"]),
                                    Estadoventaid = Convert.ToInt32(reader["EstadoVentaId"]),
                                    Transporteid = reader["TransporteId"] != DBNull.Value ? Convert.ToInt32(reader["TransporteId"]) : (int?)null,
                                    Productorid = reader["ProductorId"] != DBNull.Value ? Convert.ToInt32(reader["ProductorId"]) : (int?)null,
                                    Clienteid = Convert.ToInt32(reader["ClienteId"])
                                };

                                ventaList.Add(venta);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            return ventaList;
        }

        public Venta GetVentaById(int ventaId)
        {
            Venta venta = null;
            Connection Cnn = new Connection();
            using (Cnn.conexion)
            {
                try
                {
                    Cnn.conexion.Open();

                    using (OracleCommand command = new OracleCommand("BEGIN :cursor := get_venta_by_id(:p_ventaid); END;", Cnn.conexion))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("cursor", OracleDbType.RefCursor, ParameterDirection.ReturnValue);
                        command.Parameters.Add("p_ventaid", OracleDbType.Int32).Value = ventaId;

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                venta = new Venta
                                {
                                    Ventaid = Convert.ToInt32(reader["VentaId"]),
                                    TipoVenta = reader["TipoVenta"].ToString(),
                                    Fechaventa = Convert.ToDateTime(reader["FechaVenta"]),
                                    Totalventa = Convert.ToDouble(reader["TotalVenta"]),
                                    Estadoventaid = Convert.ToInt32(reader["EstadoVentaId"]),
                                    Transporteid = reader["TransporteId"] != DBNull.Value ? Convert.ToInt32(reader["TransporteId"]) : (int?)null,
                                    Productorid = reader["ProductorId"] != DBNull.Value ? Convert.ToInt32(reader["ProductorId"]) : (int?)null,
                                    Clienteid = Convert.ToInt32(reader["ClienteId"])
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

            return venta;
        }
        
        public List<Venta> GetVentaByType(string tipoventa)
        {
            List<Venta> ventaList = new List<Venta>();
            Connection Cnn = new Connection();
            using (Cnn.conexion)
            {
                try
                {
                    Cnn.conexion.Open();

                    using (OracleCommand command = new OracleCommand("BEGIN :cursor := get_venta_by_type(:p_tipoventa); END;", Cnn.conexion))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("cursor", OracleDbType.RefCursor, ParameterDirection.ReturnValue);
                        command.Parameters.Add("p_tipoventa", OracleDbType.Varchar2).Value = tipoventa;

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Venta venta = new Venta
                                {
                                    Ventaid = Convert.ToInt32(reader["VentaId"]),
                                    TipoVenta = reader["TipoVenta"].ToString(),
                                    Fechaventa = Convert.ToDateTime(reader["FechaVenta"]),
                                    Totalventa = Convert.ToDouble(reader["TotalVenta"]),
                                    Estadoventaid = Convert.ToInt32(reader["EstadoVentaId"]),
                                    Transporteid = reader["TransporteId"] != DBNull.Value ? Convert.ToInt32(reader["TransporteId"]) : (int?)null,
                                    Productorid = reader["ProductorId"] != DBNull.Value ? Convert.ToInt32(reader["ProductorId"]) : (int?)null,
                                    Clienteid = reader["TransporteId"] != DBNull.Value ? Convert.ToInt32(reader["ClienteId"]) : (int?)null,
                                };

                                ventaList.Add(venta);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }

                
            }

            return ventaList;
        }

        public bool ActualizarVenta(Venta c)
        {

            try
            {
                Connection Cnn = new Connection();
                Comando.Connection = Cnn.conexion;
                Comando.CommandText = "update_ventas";
                Comando.CommandType = CommandType.StoredProcedure;
                Cnn.conexion.Open();
                Comando.Parameters.Add(new OracleParameter("p_ventaid", OracleDbType.Int32) { Value = c.Ventaid });
                Comando.Parameters.Add(new OracleParameter("p_fechaventa", OracleDbType.Date) { Value = c.Fechaventa });
                Comando.Parameters.Add(new OracleParameter("p_tipoventa", OracleDbType.Varchar2) { Value = c.TipoVenta });
                Comando.Parameters.Add(new OracleParameter("p_totalventa", OracleDbType.Single) { Value = c.Totalventa });
                Comando.Parameters.Add(new OracleParameter("p_estadoventaid", OracleDbType.Int32) { Value = c.Estadoventaid });
                Comando.Parameters.Add(new OracleParameter("p_transporteid", OracleDbType.Int32) { Value = c.Transporteid });
                Comando.Parameters.Add(new OracleParameter("p_productorid", OracleDbType.Int32) { Value = c.Productorid });
                Comando.Parameters.Add(new OracleParameter("p_clienteid", OracleDbType.Int32) { Value = c.Clienteid });

                try
                {
                    Comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
                
                Comando.Parameters.Clear();
                Cnn.conexion.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool EstadoVenta(int id, int state)
        {

            try
            {
                Connection Cnn = new Connection();
                Comando.Connection = Cnn.conexion;
                Comando.CommandText = "state_ventas";
                Comando.CommandType = CommandType.StoredProcedure;
                Cnn.conexion.Open();
                Comando.Parameters.Add(new OracleParameter("p_ventaid", OracleDbType.Int32) { Value = id });
                Comando.Parameters.Add(new OracleParameter("p_estadoventaid", OracleDbType.Int32) { Value = state });

                try
                {
                    Comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }

                Comando.Parameters.Clear();
                Cnn.conexion.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool EliminarVenta(int id)
        {
            try
            {
                Connection Cnn = new Connection();
                Comando.Connection = Cnn.conexion;
                Comando.CommandText = "delete_ventas";
                Comando.CommandType = CommandType.StoredProcedure;
                Cnn.conexion.Open();
                Comando.Parameters.Add(new OracleParameter("p_ventaid", OracleDbType.Int32) { Value = id });
                Comando.ExecuteNonQuery();
                Comando.Parameters.Clear();
                Cnn.conexion.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }

        public bool InsertarVentaProducto(Venta_Producto c)
        {
            try
            {
                Connection Cnn = new Connection();
                Comando.Connection = Cnn.conexion;
                Comando.CommandText = "insert_venta_producto";
                Comando.CommandType = CommandType.StoredProcedure;
                Cnn.conexion.Open();
                Comando.Parameters.Add(new OracleParameter("p_ventaid", OracleDbType.Int32) { Value = c.Ventaid });
                Comando.Parameters.Add(new OracleParameter("p_productoid", OracleDbType.Int32) { Value = c.Productoid });
                Comando.Parameters.Add(new OracleParameter("p_cantidad", OracleDbType.Int32) { Value = c.Cantidad });

                try
                {
                    Comando.ExecuteNonQuery();
                    Comando.Parameters.Clear();
                    Cnn.conexion.Close();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Comando.Parameters.Clear();
                    Cnn.conexion.Close();
                    return false;
                }
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool EliminarVentaProducto(Venta_Producto c)
        {
            try
            {
                Connection Cnn = new Connection();
                Comando.Connection = Cnn.conexion;
                Comando.CommandText = "delete_venta_producto";
                Comando.CommandType = CommandType.StoredProcedure;
                Cnn.conexion.Open();
                Comando.Parameters.Add(new OracleParameter("p_ventaid", OracleDbType.Int32) { Value = c.Ventaid });
                Comando.Parameters.Add(new OracleParameter("p_productoid", OracleDbType.Int32) { Value = c.Productoid });
                Comando.ExecuteNonQuery();
                Comando.Parameters.Clear();
                Cnn.conexion.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }

        public int GetVentaSeq()
        {
            int seq = 0;
            Connection Cnn = new Connection();
            using (Cnn.conexion)
            {
                try
                {
                    Cnn.conexion.Open();

                    using (OracleCommand command = new OracleCommand("BEGIN :cursor := get_venta_seq; END;", Cnn.conexion))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("cursor", OracleDbType.RefCursor, ParameterDirection.ReturnValue);

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                seq = Convert.ToInt32(reader["Last_Number"]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            return seq;
        }

    }
}
