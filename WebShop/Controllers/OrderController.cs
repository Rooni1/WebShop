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

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] CreateOrderViewModel createOrder)
        {
           
            _orderService.Add(createOrder);
            return View();
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            _orderService.All();
            return View();
        }

        [HttpGet]
        [Route("FindById")]
        public IActionResult FindById(int id)
        {

            _orderService.FindBy(id);
            return View();
        }

        [HttpDelete("{id}")]
        [Route("Delete")]
        public ActionResult Delete(int id)
        {
            _orderService.Remove(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        [Route("Update")]
        public IActionResult Update(int id, UpdateOrderViewModel oredrToUpdate)
        {
            _orderService.Edit(id, oredrToUpdate);
            return NoContent();
        }


    }
}
