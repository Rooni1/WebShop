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
	[Route("api/[controller]")]
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
		[Route("Create")]
		public IActionResult Create([FromBody] CreateOrderViewModel createOrder)
		{

			_orderService.Add(createOrder);
			return View();
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

		//[HttpGet]
		//public ActionResult<List<OrderViewModel>> GetAll()
		//    {
		//		return _orderService.All();
		//    }

		/// <summary>
		///
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("FindById")]
		public IActionResult FindById(int id)
		{

			_orderService.FindBy(id);
			return View();
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
		/// <param name="oredrToUpdate"></param>
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
