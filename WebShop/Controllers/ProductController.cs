// Time-stamp: <2021-11-01 22:31:03 stefan>

using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

using WebShop.Models.Entities;
using WebShop.Models.Service;
using WebShop.ViewModels;

namespace WebShop.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
	private readonly ILogger<ProductController> _loggdest;
	private readonly IProductService _productService;

	public ProductController( ILogger<ProductController> loggdest,
				  IProductService productService)
	{
	    _loggdest=loggdest;
	    _productService = productService;
	}

	/// <summary>
	/// få ut en vymodell med produkterna
	/// </summary>
	/// <returns>ActionResult<List<ProductViewModel>></returns>
	[HttpGet]
	public ActionResult<List<ProductViewModel>> GetAll()  // API mot JS
	{
	    _loggdest.LogInformation( "public ActionResult<List<ProductViewModel>> GetAll()");

	    List<ProductViewModel> products = _productService.All();

	    return Ok(products);

	    //return Ok( _productService.All());
	}

	/// <summary>
	/// Få uppgifter om en viss produkt
	/// </summary>
	/// <param name="id"></param>
	/// <returns>Product</returns>
	[HttpGet("{id}")]
	public ActionResult<ProductViewModel> Get(int id)  // API mot JS
	{
	    _loggdest.LogInformation( "public ActionResult<ProductViewModel> Get(int id)");

	    ProductViewModel product = _productService.FindBy(id);

	    return Ok(product);
	}

	/// <summary>
	///
	/// </summary>
	[HttpPost]
	public ActionResult Create([FromBody] CreateProductViewModel product)  // API mot JS
	{
	    _loggdest.LogInformation( "public ActionResult Create([FromBody] CreateProductViewModel product)");

	    _productService.Add(product);

	    return NoContent();
	}

	/// <summary>
	/// modifiering i sortimentet av uppgifter om en viss produkt
	/// </summary>
	[HttpPut("{id}")]
	[Route("Update")]
	public IActionResult Update(int id, UpdateProductViewModel product)  // API mot JS
	{
	    _loggdest.LogInformation( "public IActionResult Update(int id, UpdateProductViewModel product)");

	    _productService.Edit(id,product);

	    return NoContent();
	}

	/// <summary>
	/// slutlig borttagning av en viss produkt i sortimentet
	/// </summary>
	[HttpDelete("{id}")]
	[Route("Delete")]
	public ActionResult Delete(int id)  // API mot JS
	{
	    _loggdest.LogInformation( "public ActionResult Delete(int id)");

	    _productService.Remove(id);

	    return NoContent();
	}
    }
}
