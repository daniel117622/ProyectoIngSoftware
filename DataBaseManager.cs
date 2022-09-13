using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace BlankApp
{
    internal class DataBaseManager
    {
        public const string connectionString = "Server = 148.239.60.61; Database=AppDanielRestaurant;User Id = ids; Password=ids;";
        // public const string connectionString = "Server = LAPTOP-AHPK0PTA\\BDLOCAL; Database = AppDanielRestaurante; User ID=ids; Password=ids;";
        public static SqlDataReader ObtenerPlatillos()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            Console.WriteLine(connection);
            try
            {
                connection.Open(); /// Esta es la linea que falla
                Console.WriteLine("Abierta conexion con exito");
                connection.ChangeDatabase("AppDanielRestaurant");
                string query = "select * from Platillos";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                return reader;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }

        }

        public static SqlDataReader ObtenerPlatillosMesa(int numeroMesa)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open(); /// Esta es la linea que falla
                Console.WriteLine("Abierta conexion con exito");
                connection.ChangeDatabase("AppDanielRestaurant");
                string query = "EXEC CuentaMesa " + numeroMesa.ToString();
                // QUEDA PENDIENTE REVISAR LA VISTA CORRESPONDIENTE PARA OBTENER PLATILLOS DE MESA EN ESPECIFICO.
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                return reader;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
            
        }
    }
}
