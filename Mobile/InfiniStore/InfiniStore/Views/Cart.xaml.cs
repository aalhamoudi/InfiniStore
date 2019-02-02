using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InfiniStore.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cart : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public Cart()
        {
            InitializeComponent();

            Items = new ObservableCollection<string>
            {
                "Product 1",
                "Product 2",
                "Product 3",
                "Product 4",
                "Product 5"
            };
			
			MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Product Tapped", "An product was tapped.", "OK");

            //Deselect Product
            ((ListView)sender).SelectedItem = null;
        }
    }
}
