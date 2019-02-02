using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using InfiniStore.Models;
using InfiniStore.ViewModels;

namespace InfiniStore.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Product : ContentPage
    {
        ProductViewModel viewModel;

        public Product(ProductViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public Product()
        {
            InitializeComponent();

            var item = new Models.Product
            {
                Text = "Product 1",
                Description = "This is an product description."
            };

            viewModel = new ProductViewModel(item);
            BindingContext = viewModel;
        }
    }
}