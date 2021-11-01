// Time-stamp: <2021-10-31 16:15:41 stefan>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

using WebShop.Models.Entities;
using WebShop.Models.Service;
using WebShop.ViewModels;

namespace WebShop.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : Controller
    {
	private readonly ILogger<OrderController> _loggdest;
	private readonly IOrderService _orderService;

	public OrderController( ILogger<OrderController> loggdest,
				IOrderService orderService)
	{
	    _loggdest = loggdest;
	    _orderService = orderService;
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="createOrder"></param>
	/// <returns></returns>
	[HttpPost]
	public IActionResult Create(CreateOrderViewModel createOrder)
	{
	    _loggdest.LogInformation( "Create([FromBody] CreateOrderViewModel createOrder)");

	    _orderService.Add(createOrder);

	    return NoContent();
	}

	/// <summary>
	/// returnera data om alla existerande ordrar i systemet
	/// </summary>
	[HttpGet]
	[Route("GetAll")]
	public IActionResult GetAll()
	{
	    _orderService.All();

	    return View();
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	[HttpGet]
	public ActionResult<Order> FindById(int id)
	{
	    return Ok(_orderService.FindBy(id));
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	[HttpDelete("{id}")]
	[Route("Delete")]
	public ActionResult Delete(int id)
	{
	    _orderService.Remove(id);

	    return NoContent();
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="id"></param>
	/// <param name="orderToUpdate"></param>
	/// <returns></returns>
	[HttpPut("{id}")]
	[Route("Update")]
	public IActionResult Update(int id, UpdateOrderViewModel orderToUpdate)
	{
	    _orderService.Edit(id, orderToUpdate);

	    return NoContent();
	}
    }
}
