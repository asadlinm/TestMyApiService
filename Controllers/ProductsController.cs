using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VeyselogluWebApiTest.Models;
using VeyselogluWebApiTest.Repositories;
using VeyselogluWebApiTest.Services;
using static VeyselogluWebApiTest.Models.GetAllProductResponse;

namespace VeyselogluWebApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [FormatFilter]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository) {
            _productRepository = productRepository;
}
      
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetAllProducts()
        {
            try
            {
                List<AllProducts> response = new List<AllProducts>();
                ProductServices service = new ProductServices(_productRepository);
                response = service.GetAllProducts();
                if (response.Count == 0) return NotFound();
                else  return Ok(response);
            }
            catch (Exception ex)
            {
                return Problem("Problem occured.");
            }
        }
    }
}
