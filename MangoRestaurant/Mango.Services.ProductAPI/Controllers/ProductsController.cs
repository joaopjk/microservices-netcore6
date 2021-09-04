using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mango.Services.ProductAPI.Model.DTO;
using Mango.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        protected ResponseDTO _response;
        private IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _response = new ResponseDTO();
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ResponseDTO> Get()
        {
            try
            {
                _response.Result = await _productRepository.GetProducts();

            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }

            return _response;
        }

        [HttpGet("{id}")]
        public async Task<ResponseDTO> GetById(int id)
        {
            try
            {
                _response.Result = await _productRepository.GetProductById(id);

            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }

            return _response;
        } 
    }
}
