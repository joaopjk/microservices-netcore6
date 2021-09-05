using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mango.Web.Models;
using Mango.Web.Service.IServices;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDTO> list = new();
            var response = await _productService.GetAllProductsAsync<ResponseDTO>();

            if (response is { IsSuccess: true })
                list = JsonConvert.DeserializeObject<List<ProductDTO>>(Convert.ToString(response.Result) ?? string.Empty);

            return View(list);
        }

        public async Task<IActionResult> ProductCreate(ProductDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.CreateProductAsync<ResponseDTO>(model);
                if (response is { IsSuccess: true })

                    return RedirectToAction(nameof(ProductIndex));
            }
            return View(model);
        }

        public async Task<IActionResult> ProductEdit(int productId)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.GetProductByIdAsync<ResponseDTO>(productId);
                if (response is { IsSuccess: true })
                {
                    ProductDTO model =
                        JsonConvert.DeserializeObject<ProductDTO>(Convert.ToString(response.Result) ?? string.Empty);
                    return View(model);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductEdit(ProductDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.UpdateProductAsync<ResponseDTO>(model);
                if (response is { IsSuccess: true })
                    return RedirectToAction(nameof(ProductIndex));
            }
            return View(model);
        }
    }
}
