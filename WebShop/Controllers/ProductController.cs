using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<ProductViewModel>> GetAll()
        {
            List<ProductViewModel> products = _productService.All();

            return Ok(products);

        }

        [HttpGet("{id}")]
        public ActionResult<ProductViewModel> Get(int id)
        {
            ProductViewModel product = _productService.FindBy(id);

            return Ok(product);
        }

        [HttpPost]
        public ActionResult Create([FromBody] CreateProductViewModel product)
        {
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
