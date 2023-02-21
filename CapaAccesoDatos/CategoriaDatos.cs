using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
    public class CategoriaDatos
    {
        //realizar la conexion dentro de la clase
        private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString);

        //metodo para la consulta de datos
        public DataTable SelectCategoriaDatos()
        {
            SqlCommand command = new SqlCommand("SelectCategoria ", connection);
            command.CommandType = CommandType.StoredProcedure; // declaramos que utilizaremos un procedimiento almacenado
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command); // se almacena y ejecuta.
            DataTable dataTable = new DataTable(); // se crea el data table
            dataAdapter.Fill(dataTable);
            return dataTable;
        }

        //Creando  metodo para insertar datos en la tabla categoria
        public bool InsertCategoria(Categoria categoria)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("InsertCategoria", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@nombreCategoria", categoria.NombreCategoria);
            command.Parameters.AddWithValue("@descripcionCategoria", categoria.DescripcionCategoria);
            int result = command.ExecuteNonQuery(); //devuelve el numero de filas afectadas
            command.Parameters.Clear(); //limpiamos los parametros
            connection.Close();


            //si las el numero de filas devuelto es mayor a cero significa
            //que los datos se insertaron correctamente
            if (result > 0)
            { 
                return true;
            }

            return false;
        }

    }
}