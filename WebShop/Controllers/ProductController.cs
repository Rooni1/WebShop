using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebShop.Models.Entities;
using WebShop.Models.Service;
using WebShop.ViewModels;

namespace WebShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(
           IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult<List<Product>> GetAll()
        {
            List<Product> products = _productService.All().products;

            return Ok(products);

        }

        [HttpGet("{id}")]
        public ActionResult<ProductViewModel> Get(int id)
        {
            Product product =  _productService.FindBy(id);

            return Ok(product);
        }

        [HttpPost]
        public ActionResult Create([FromBody] CreateProductViewModel product)
        {
            _productService.Add(product);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] UpdateProductViewModel product)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            return NoContent();
        }
    }
}
