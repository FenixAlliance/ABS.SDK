using System.Collections.Generic;
using System.Threading.Tasks;

namespace FenixAlliance.Passport.Pocket.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(string Token, bool forceRefresh = false);
    }
}
