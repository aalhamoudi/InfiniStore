using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using InfiniStore.Models;
using InfiniStore.Views;
using InfiniStore.ViewModels;

namespace InfiniStore.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Products : ContentPage
    {
        ProductsViewModel viewModel;

        public Products()
        {
            InitializeComponent();

            BindingContext = viewModel = new ProductsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Models.Product;
            if (item == null)
                return;

            await Navigation.PushAsync(new Product(new ProductViewModel(item)));

            // Manually deselect product.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}