using Datos.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Accesos
{
    public class ProductoDA
    {
        readonly string cadena = "Server=localhost; Port=3306; Database=examengolosinas; Uid=root; Pwd=alfaete01;";


        MySqlConnection conn;
        MySqlCommand cmd;


        public DataTable ListaProductos()
        {
            DataTable listap = new DataTable();

            try
            {
                string sql = "SELECT * FROM productp;";
                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                MySqlDataReader reader = cmd.ExecuteReader();
                listap.Load(reader);
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {

            }
            return listap;
        }

        public bool InsertaProductp(Producto producto)
        {
            bool insert = false;
            try
            {
                string sql = "INSERT INTO producto VALUES (@Codigo, @Descripcion, @Precio, @Existencia);";

                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Codigo", producto.Codigo);
                cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                cmd.Parameters.AddWithValue("@Precio", producto.Precio);
                cmd.Parameters.AddWithValue("@Existencia", producto.Existencia);

                cmd.ExecuteNonQuery();
                insert = true;

            }
            catch (Exception)
            {

            }
            return insert;
        }

        public bool ModificarProducto(Producto producto)
        {
            bool modifico = false;
            try
            {
                string sql = "UPDATE productp SET Codigo = @Codigo, Descripcion = @Descripcion, Precio = @Precio, Existencia = @Existencia WHERE Codigo = @Codigo);";

                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);


                cmd.Parameters.AddWithValue("@Codigo", producto.Codigo);
                cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                cmd.Parameters.AddWithValue("@Precio", producto.Precio);
                cmd.Parameters.AddWithValue("@Existencia", producto.Existencia);



                cmd.ExecuteNonQuery();
                modifico = true;
                conn.Close();

            }
            catch (Exception)
            {

            }
            return modifico;
        }

        public bool EliminarProducto(string codigo)
        {
            bool elimino = false;
            try
            {
                string sql = "DELETE FROM producto WHERE Codigo = @Codigo;";

                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Codigo", codigo);

                cmd.ExecuteNonQuery();
                elimino = true;
                conn.Close();
            }
            catch (Exception ex)
            {
            }
            return elimino;
        }

    }
}
