using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnection;
using Models;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace Controller
{
    public class CProducto
    {
        OracleCommand Comando = new OracleCommand();

        public bool InsertarProducto(Producto c)
        {
            try
            {
                Connection Cnn = new Connection();
                Comando.Connection = Cnn.conexion;
                Comando.CommandText = "insert_producto";
                Comando.CommandType = CommandType.StoredProcedure;
                Cnn.conexion.Open();
                Comando.Parameters.Add(new OracleParameter("p_nombre", OracleDbType.Varchar2) { Value = c.Nombre });
                Comando.Parameters.Add(new OracleParameter("p_precio", OracleDbType.Decimal) { Value = c.Precio });
                Comando.Parameters.Add(new OracleParameter("p_stock", OracleDbType.Int32) { Value = c.Stock });
                Comando.Parameters.Add(new OracleParameter("p_productorid", OracleDbType.Int32) { Value = c.Stock });
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

        public List<Producto> GetAllProductos()
        {
            List<Producto> productoList = new List<Producto>();
            Connection Cnn = new Connection();
            using (Cnn.conexion)
            {
                try
                {
                    Cnn.conexion.Open();

                    using (OracleCommand command = new OracleCommand("BEGIN :cursor := get_all_productos; END;", Cnn.conexion))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("cursor", OracleDbType.RefCursor, ParameterDirection.ReturnValue);

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Producto producto = new Producto
                                {
                                    Productoid = Convert.ToInt32(reader["ProductoId"]),
                                    Nombre = reader["Nombre"].ToString(),
                                    Precio = Convert.ToSingle(reader["Precio"]),
                                    Stock = Convert.ToInt32(reader["Stock"]),
                                    Productorid = Convert.ToInt32(reader["ProductorId"])
                                };

                                productoList.Add(producto);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            return productoList;
        }

        public List<Producto> GetProductosbyProductor(int productorid)
        {
            List<Producto> productoList = new List<Producto>();
            Connection Cnn = new Connection();
            using (Cnn.conexion)
            {
                try
                {
                    Cnn.conexion.Open();

                    using (OracleCommand command = new OracleCommand("BEGIN :cursor := get_productos_by_productor(:p_productorid); END;", Cnn.conexion))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("cursor", OracleDbType.RefCursor, ParameterDirection.ReturnValue);
                        command.Parameters.Add("p_productorid", OracleDbType.Int32).Value = productorid;

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Producto producto = new Producto
                                {
                                    Productoid = Convert.ToInt32(reader["ProductoId"]),
                                    Nombre = reader["Nombre"].ToString(),
                                    Precio = Convert.ToSingle(reader["Precio"]),
                                    Stock = Convert.ToInt32(reader["Stock"]),
                                    Productorid = Convert.ToInt32(reader["ProductorId"])
                                };

                                productoList.Add(producto);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            return productoList;
        }

        public Producto GetProductosById(int productoId)
        {
            Producto producto = null;
            Connection Cnn = new Connection();
            using (Cnn.conexion)
            {
                try
                {
                    Cnn.conexion.Open();

                    using (OracleCommand command = new OracleCommand("BEGIN :cursor := get_productos_by_id(:p_productoid); END;", Cnn.conexion))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.Add("cursor", OracleDbType.RefCursor, ParameterDirection.ReturnValue);
                        command.Parameters.Add("p_productoid", OracleDbType.Int32).Value = productoId;

                        using (OracleDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                producto = new Producto
                                {
                                    Productoid = Convert.ToInt32(reader["ProductoId"]),
                                    Nombre = reader["Nombre"].ToString(),
                                    Precio = Convert.ToSingle(reader["Precio"]),
                                    Stock = Convert.ToInt32(reader["Stock"])
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

            return producto;
        }


        public bool ActualizarProducto(Producto c)
        {
            try
            {
                Connection Cnn = new Connection();
                Comando.Connection = Cnn.conexion;
                Comando.CommandText = "update_producto";
                Comando.CommandType = CommandType.StoredProcedure;
                Cnn.conexion.Open();
                Comando.Parameters.Add(new OracleParameter("p_nombre", OracleDbType.Varchar2) { Value = c.Nombre });
                Comando.Parameters.Add(new OracleParameter("p_precio", OracleDbType.Decimal) { Value = c.Precio });
                Comando.Parameters.Add(new OracleParameter("p_stock", OracleDbType.Int32) { Value = c.Stock });
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

        public bool EliminarProducto(int id)
        {
            try
            {
                Connection Cnn = new Connection();
                Comando.Connection = Cnn.conexion;
                Comando.CommandText = "delete_contrato";
                Comando.CommandType = CommandType.StoredProcedure;
                Cnn.conexion.Open();
                Comando.Parameters.Add(new OracleParameter("p_contratoid", OracleDbType.Int32) { Value = id });
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
    }
}
