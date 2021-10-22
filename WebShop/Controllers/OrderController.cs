using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models.Entities;
using WebShop.Models.Service;
using WebShop.ViewModels;

namespace WebShop.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : Controller
    {
	private readonly IOrderService _orderService;
	public OrderController(IOrderService orderService)
	{
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
	    _orderService.Add(createOrder);

	    return NoContent();
	}

	/// <summary>
	/// returnera data om alla existerande ordrar i systemet
	/// </summary>
	/// <returns></returns>
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
	public IActionResult Update(int id, UpdateOrderViewModel oredrToUpdate)
	{
	    _orderService.Edit(id, oredrToUpdate);

	    return NoContent();
	}
    }
}
