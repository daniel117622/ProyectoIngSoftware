using System;
using Xamarin.Forms;

namespace BlankApp
{
    public partial class StartingPage : ContentPage

    {
        
        public StartingPage()
        {
            InitializeComponent(); // Initialize component toma el XAML para modificar el content
        }

        private async void SendToRestaurantPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RestaurantPage());
        }

        private async void SendToClientPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ClientPage());
        }
    }
}
