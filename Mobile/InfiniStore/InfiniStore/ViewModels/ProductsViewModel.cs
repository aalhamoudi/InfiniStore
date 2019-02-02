using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using InfiniStore.Models;
using InfiniStore.Views;
using Product = InfiniStore.Models.Product;

namespace InfiniStore.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        public ObservableCollection<Product> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ProductsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Product>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            /*MessagingCenter.Subscribe<NewItemPage, Product>(this, "AddItem", async (obj, product) =>
            {
                var newItem = product as Product;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });*/
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}