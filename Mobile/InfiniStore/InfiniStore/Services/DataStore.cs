using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfiniStore.Models;

namespace InfiniStore.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }

    public class DataStore : IDataStore<Product>
    {
        List<Product> items;

        public DataStore()
        {
            items = new List<Product>();
            var mockItems = new List<Product>
            {
                new Product { Id = Guid.NewGuid().ToString(), Text = "First product", Description="This is an product description." },
                new Product { Id = Guid.NewGuid().ToString(), Text = "Second product", Description="This is an product description." },
                new Product { Id = Guid.NewGuid().ToString(), Text = "Third product", Description="This is an product description." },
                new Product { Id = Guid.NewGuid().ToString(), Text = "Fourth product", Description="This is an product description." },
                new Product { Id = Guid.NewGuid().ToString(), Text = "Fifth product", Description="This is an product description." },
                new Product { Id = Guid.NewGuid().ToString(), Text = "Sixth product", Description="This is an product description." },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Product product)
        {
            items.Add(product);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Product product)
        {
            var oldItem = items.Where((Product arg) => arg.Id == product.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(product);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Product arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Product> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Product>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}