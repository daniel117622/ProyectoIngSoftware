using System;
using System.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Data.SqlClient;


namespace BlankApp
{
    public partial class App : Application
    {
       
        public App()
        {
            InitializeComponent();
            Console.WriteLine("Executing APP constructor");
            MainPage = new NavigationPage(new StartingPage());

            // We initialize a ContentPage instance that we defined in MainPage.xaml.cs

            /* Code that can read a full table of Platillos
            SqlDataReader reader = DataBaseManager.ObtenerPlatillos();
            while (reader.Read())
            {
                Console.WriteLine(String.Format("ID: {0} Nombre: {1} Costo: {2}", reader["Id"], reader["Nombre"], reader["Precio"]));
            }
            */ 
        }

        
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
