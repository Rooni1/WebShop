// Time-stamp: <2021-10-31 15:52:43 stefan>

using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using WebShop.Models.Entities;
using WebShop.Models.Service;
using WebShop.ViewModels;

namespace WebShop.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
	private readonly IProductService _productService;

	public ProductController(IProductService productService)
	{
	    _productService = productService;
	}

	[HttpGet]
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
	    _productService.Add(product);

	    return NoContent();
	}

	[HttpPut("{id}")]
	[Route("Update")]
	public IActionResult Update(int id, UpdateProductViewModel product)
	{
	    _productService.Edit(id,product);

	    return NoContent();
	}

	[HttpDelete("{id}")]
	[Route("Delete")]
	public ActionResult Delete(int id)
	{
	    _productService.Remove(id);

	    return NoContent();
	}
    }
}
