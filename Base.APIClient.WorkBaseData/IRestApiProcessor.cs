using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Base.APIClient.WorkBaseData
{
    public interface IRestApiProcessor
    {
        string ErrorResult { get; }

        Task<List<T>> GetList<T>(string route);
        Task<Uri> CreateAsync<T>(T api, string route);
        Task<HttpStatusCode> DeleteAsync(Guid id, string route);
        Task<T> GetByIdAsync<T>(Guid id, string route);
        Task<T> GetByNumberAsync<T>(int number, string route);
        Task<HttpStatusCode> UpdateAsync<T>(T api, Guid id, string route);
    }
}