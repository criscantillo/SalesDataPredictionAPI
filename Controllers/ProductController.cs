using Microsoft.AspNetCore.Mvc;
using SalesDataPredictionAPI.Models.Data;
using SalesDataPredictionAPI.Models.Repository;

namespace SalesDataPredictionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository) => _productRepository = productRepository;

        [HttpGet]
        [ActionName(nameof(GetProductsAsync))]
        public IEnumerable<Product> GetProductsAsync()
        {
            return _productRepository.GetAsync();
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetProductById))]
        public ActionResult<Product> GetProductById(int id)
        {
            var productById = _productRepository.GetByIdAsync(id);
            if (productById == null)
                return NotFound();

            return productById;
        }
    }
}
