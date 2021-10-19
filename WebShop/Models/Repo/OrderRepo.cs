using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebShop.Data;
using WebShop.Models.Entities;
using WebShop.ViewModels;

namespace WebShop.Models.Repo
{
    public class OrderRepo : IOrderRepo
    {
        private readonly DBWebShop _dBWebShop;
        public OrderRepo(DBWebShop dBWebShop)
        {
            _dBWebShop = dBWebShop;
        }
        public void Create(CreateOrderViewModel createOrder)
        {
            Order newOrder = new Order
            {
                OrderId = createOrder.OrderId,
                OrderDate = createOrder.OrderDate
            };
            for (int i = 0; i < createOrder.OrderItems.Count;  i++)
            {
                OrderItem itemsOrdered = new OrderItem
                {
                    OrderId = newOrder.OrderId,
                    Quantity = createOrder.OrderItems[i].Quantity,
                    ProductId = createOrder.OrderItems[i].ProductId
                  
                };
                _dBWebShop.Add(newOrder);
                _dBWebShop.SaveChanges();
                _dBWebShop.Add(itemsOrdered);
                _dBWebShop.SaveChanges();
            }

	    _dBWebShop.SaveChanges();
	}

	/// <summary>
	/// modifiering av en viss order
	///  ersätter Edit i IOrderItem ?
	/// </summary>
	/// <param name="Id"></param>
	/// <returns></returns>
	public void Edit(int id, UpdateOrderViewModel updateOrder)
	{
	    Order orderToUpdate = FindById(id);
	    orderToUpdate.OrderDate = updateOrder.OrderDate;
	    _dBWebShop.Update(orderToUpdate);
	    _dBWebShop.SaveChanges();

	    for (int i = 0; i < updateOrder.OrderItems.Count; i++)
	    {
		orderToUpdate.OrderId = id;
		orderToUpdate.OrderItems[i].ProductId = updateOrder.OrderItems[i].ProductId;
		orderToUpdate.OrderItems[i].Quantity = updateOrder.OrderItems[i].Quantity;
	    }
	    _dBWebShop.Update(orderToUpdate);
	    _dBWebShop.SaveChanges();
	}

	/// <summary>
	/// vilka order har en viss kund sedan tidigare
	/// </summary>
	/// <param name="CustomerId"></param>
	/// <returns></returns>
	public List<Order> FindByCustomer(int CustomerId)
	{
	    throw new NotImplementedException();
	}

	/// <summary>
	/// sökning efter en viss order
	/// </summary>
	/// <param name="Id"></param>
	/// <returns></returns>
	public Order FindById(int Id)
	{
	    orders = _dBWebShop.Order.ToList();

	    foreach (Order item in orders)
	    {
		if (item.OrderId == Id)
		{
		    return item;
		}
	    }
	    return null;
	}

	public void Delete(int Id)
	{
	    Order OrderToDelete = FindById(Id);
	    _dBWebShop.Remove(OrderToDelete);
	    _dBWebShop.SaveChanges();
	}
    }
}
