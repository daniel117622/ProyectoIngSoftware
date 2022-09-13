using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.ComponentModel;

using Xamarin.Forms;

namespace BlankApp
{
    public partial class RestaurantPage : ContentPage
    {
        
        public RestaurantPage()
        {
            InitializeComponent(); // Initialize component toma el XAML para modificar el content
        }

        private void Button_Mesa(object sender, EventArgs e)
        {
            var mesa_seleccionada = (sender as Button).Text;
            Console.WriteLine(mesa_seleccionada);
            Application.Current.Properties["Name"] = mesa_seleccionada.ToString();
            Navigation.PushAsync(new NavigationPage(new MesaPage()));
        }

        public static List<CuentaMesa> calculateMesa(int mesa)
        {
            SqlDataReader reader = DataBaseManager.ObtenerPlatillosMesa(mesa);
            List<CuentaMesa> items = new List<CuentaMesa>();
            var i = 0;
            try
            {
                while (reader.Read())
                {
                    var mesa_ = int.Parse(reader["mesa"].ToString());
                    var name = reader["nombre"].ToString();
                    var desc = int.Parse(reader["Cantidad"].ToString());
                    var cost = float.Parse(reader["Precio_Unitario"].ToString());

                    var cuentaMesa_ = new CuentaMesa(mesa_,name,desc,cost);


                    items.Add(cuentaMesa_);
                    i++;
                }
                return items;
            }
            catch (Exception ex)
            {
                // When there is no connection. Fallback items will be spawned

                Console.WriteLine("Error en el acceso a la database: " +  ex.Message);
                for (i = 0; i < 3; i++)
                {
                    var platillo = new CuentaMesa(666,"no connection",0,0);
                    items.Add(platillo);
                }

                return items;
            }
        }


            
    }
}
