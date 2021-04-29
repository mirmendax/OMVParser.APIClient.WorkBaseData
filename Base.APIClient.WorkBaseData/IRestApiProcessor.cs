using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Base.APIClient.WorkBaseData
{
    public interface IRestApiProcessor
    {
        string ErrorResult { get; }

        Task<List<T>> GetItemsAsync<T>(string route);
        Task<T> CreateAsync<T>(T api, string route);
        Task<HttpStatusCode> DeleteAsync<T>(Guid id, string route);
        Task<T> GetItemAsync<T>(Guid id, string route);
        Task<T> GetItemAsync<T>(int number, string route);
        Task<T> UpdateAsync<T>(T api, Guid id, string route);
    }
}