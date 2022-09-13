using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlankApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientPage : ContentPage
    {
        public ObservableCollection<Platillo> ItemsCollection { get; } = new ObservableCollection<Platillo>(calculateItems());  // Utilizamos el constructor que toma una lista

        private static int[] _Mesas = new int[]
        {
            1,2, 3, 4, 5, 6, 7,8
        };
        public ObservableCollection<int> Mesas { get; } = new ObservableCollection<int>(new List<int>(_Mesas));

        public Ticket ticket { get; } = new Ticket(0.0f,0,0);


        public ClientPage()
        {
            InitializeComponent();
 
            BindingContext = this;
        }

        public static List<Platillo> calculateItems()
        {
            SqlDataReader reader = DataBaseManager.ObtenerPlatillos(); // Solamente obtiene el reader para trabajar con el

            List<Platillo> items = new List<Platillo>();
            var i = 0;
            try
            {
                while (reader.Read())
                {
                    var Id = int.Parse(reader["id"].ToString());
                    var name = reader["Nombre"].ToString();
                    var desc = reader["Descripcion"].ToString();
                    var cost = reader["Precio"].ToString();

                    var platillo = new Platillo(Id,name, desc, cost);


                    items.Add(platillo);
                    i++;
                }
                return items;
            }
            catch (Exception ex)
            {
                // When there is no connection. Fallback items will be spawned
                
                Console.WriteLine("Error en el acceso a la database: ", ex.Message);
                for (i = 0; i < 3; i++)
                {
                    var platillo = new Platillo(i ,"Platillo " + i.ToString(), "Lorem Ipsum Dolor Sit et Amet Desc", "10.50");
                    items.Add(platillo);
                }

                return items;
            }

        }
        
        private void Add_Item(object sender, EventArgs e)
        {
            try
            {
                Button button = sender as Button;
                Grid grid = (button.Parent.Parent as Grid);
                float price = float.Parse((grid.Children[2] as Label).Text);

                // Codigo para anadir al carrito de compras
                string nombrePLatillo = (grid.Children[0] as Label).Text;
                Console.WriteLine(nombrePLatillo);
                IEnumerator<Platillo> i = ItemsCollection.GetEnumerator();
                while (i.MoveNext())
                {
                    if (i.Current.Nombre == nombrePLatillo)
                    {
                        ticket.lista.Add(i.Current);
                        Console.WriteLine("Se anadio " + i.Current.Nombre + " al carrito de compras");
                        break;
                    }
                }

                ticket.Cantidad += 1;
                ticket.Total += price;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void Remove_Item(object sender, EventArgs e)
        {
            try
            {

                Button button = sender as Button;
                Grid grid = (button.Parent.Parent as Grid);
                float price = float.Parse((grid.Children[2] as Label).Text);
                bool isItemInCart = false;

                string nombrePLatillo = (grid.Children[0] as Label).Text;
                IEnumerator<Platillo> i = ticket.lista.GetEnumerator();

                while (i.MoveNext())
                {
                    if (i.Current.Nombre == nombrePLatillo)
                    {
                        ticket.lista.Remove(i.Current);
                        isItemInCart = true;
                        break;
                    }
                }
                //  Antes de realizar esta accion debemos verificar si el item existe en el carrito
                if (isItemInCart)
                {
                    ticket.Cantidad -= 1;
                    ticket.Total -= price;
                }
                else
                {
                    Console.WriteLine("Ya no esta ese item en el carrito!");
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void OnSubmit(object sender, EventArgs e)
        {
            Console.WriteLine("Total: " + ticket.Total);
            Console.WriteLine("Cantidad: " + ticket.Cantidad);
            Console.WriteLine("Mesa: " + ticket.Mesa);

            // Queda pendiente utilizar un procediemiento almacenada para subir esa orden a la base de datos

            SqlConnection connection = new SqlConnection(DataBaseManager.connectionString);
            try
            {
                connection.Open();
                connection.ChangeDatabase("AppDanielRestaurant");

                var tableNumber = (((sender as View).Parent as Grid).Children[1] as Picker).SelectedItem;
                if (tableNumber == null) { tableNumber = 1; }

                // Iterate through ticket.lista and send everything as an order

                IEnumerator<Platillo> i = ticket.lista.GetEnumerator();

                while(i.MoveNext())
                {
                    string query = "AgregarOrden " + i.Current.Id.ToString() + "," + tableNumber.ToString() + ",\'SQLSERVERTEST\'";
                    SqlCommand command = new SqlCommand(query, connection);
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine("OrderSubmitted: Changed " + rowsAffected.ToString());
                }


            }
            catch(Exception ex)
            {
                Console.WriteLine("An exception ocurred on Submit: " +  ex.Message);
            }

        }

        private void OnItemSelection(object sender, EventArgs e)
        {
            var picker = (sender as Picker);
            int mesa = int.Parse(picker.Items[picker.SelectedIndex]);
            ticket.Mesa = mesa;           
        }
    }
}