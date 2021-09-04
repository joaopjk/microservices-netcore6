using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Mango.Services.ProductAPI.DbContext;
using Mango.Services.ProductAPI.Model;
using Mango.Services.ProductAPI.Model.DTO;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var products = await _db.Products.ToListAsync();
            return _mapper.Map<List<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetProductById(int productId)
        {
            var product = await _db.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
            return _mapper.Map<ProductDTO>(product);
        }

        public Task<ProductDTO> CreateUpdateProduct(ProductDTO productDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteProduct(int productId)
        {
            throw new System.NotImplementedException();
        }
    }
}
