using System.Threading.Tasks;
using Mango.Web.Models;

namespace Mango.Web.Service.IServices
{
    public interface IProductService
    {
        Task<T> GetAllProductsAsync<T>();
        Task<T> GetProductByIdAsync<T>(int id);
        Task<T> CreateProductAsync<T>(ProductDTO productDto);
        Task<T> UpdateProductAsync<T>(ProductDTO productDto);
        Task<T> DeleteProductAsync<T>(int id);
    }
}
