using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlankApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MesaPage : ContentPage
    {
        public static int mesa_seleccionada = int.Parse(Application.Current.Properties["Name"].ToString());
        public ObservableCollection<CuentaMesa> CuentaMesas { get; } = new ObservableCollection<CuentaMesa>(RestaurantPage.calculateMesa(mesa_seleccionada));
        public MesaPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine(Navigation.NavigationStack[Navigation.NavigationStack.Count - 1].ToString());
                Navigation.PopToRootAsync();
                Console.WriteLine(Navigation.NavigationStack[Navigation.NavigationStack.Count - 1].ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Not popped");
            }          
        }
    }
}