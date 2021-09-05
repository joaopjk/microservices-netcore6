using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mango.Services.ProductAPI.Model.DTO;
using Mango.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost]
        public async Task<ResponseDTO> Post([FromBody] ProductDTO productDto)
        {
            try
            {
                _response.Result = await _productRepository.CreateUpdateProduct(productDto);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }
            return _response;
        }

        [HttpPut]
        public async Task<ResponseDTO> Put([FromBody] ProductDTO productDto)
        {
            try
            {
                _response.Result = await _productRepository.CreateUpdateProduct(productDto);
            }
            catch (Exception e)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }
            return _response;
        }

        [HttpDelete("{productId}")]
        public async Task<ResponseDTO> Delete(int productId)
        {
            try
            {
                _response.Result = await _productRepository.DeleteProduct(productId);
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
