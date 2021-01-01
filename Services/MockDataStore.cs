using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FenixAlliance.Models.DTOs.Components.Store;
using Newtonsoft.Json;

namespace FenixAlliance.Passport.Pocket.Services
{
    public class MockDataStore : IDataRepository<Product>
    {
        List<Product> Products;

        public static string ApiEndpoint = "https://fenixalliance.com.co/api/andy/products";

        public MockDataStore()
        {
            Products = new List<Product>();
        }

        public async Task<bool> AddItemAsync(Product item)
        {
            Products.Add(item);

            return true;
        }

        public async Task<bool> UpdateItemAsync(Product item)
        {
            var oldItem = Products.Where((Product arg) => arg.ID == item.ItemID).FirstOrDefault();
            Products.Remove(oldItem);
            Products.Add(item);

            return true;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = Products.Where((Product arg) => (string)arg.ItemID == id).FirstOrDefault();
            Products.Remove(oldItem);

            return true;
        }

        public async Task<Product> GetItemAsync(string id)
        {
            return Products.FirstOrDefault(s => (string)s.ItemID == id);
        }

        public async Task<IEnumerable<Product>> GetItemsAsync(string AuthToken, bool forceRefresh = false)
        {
            try
            {
                // Get data from API
                HttpClient client = new HttpClient();
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, ApiEndpoint);
                message.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AuthToken);
                HttpResponseMessage response = await client.SendAsync(message);
                string responseString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Response from API {ApiEndpoint} | {responseString}");
                    Products = JsonConvert.DeserializeObject<List<Product>>(responseString);
                }
                else
                {
                    Console.WriteLine($"Error calling API {ApiEndpoint} | {responseString}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error on authentication." + ex.ToString());
            }

            return Products;
        }
    }
}