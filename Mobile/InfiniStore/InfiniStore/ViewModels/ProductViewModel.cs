using System;

using InfiniStore.Models;

namespace InfiniStore.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        public Product Product { get; set; }
        public ProductViewModel(Product product = null)
        {
            Title = product?.Text;
            Product = product;
        }
    }
}
