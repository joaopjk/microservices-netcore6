using System;
using System.Threading.Tasks;
using Mango.Web.Models;

namespace Mango.Web.Service.IServices
{
    public interface IBaseService : IDisposable
    {
        ResponseDTO responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
