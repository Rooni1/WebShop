//
// Time-stamp: <2021-10-31 17:16:46 stefan>
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using WebShop.Data;
using WebShop.Models.Entities;
using WebShop.ViewModels;

namespace WebShop.Models.Repo
{
    public class OrderRepo : IOrderRepo
    {
	private readonly DBWebShop _dBWebShop;

	List<OrderItem> OrderItems = new List<OrderItem>();
	List<Order> orders = new List<Order>();

	public OrderRepo(DBWebShop dBWebShop)
	{
	    _dBWebShop = dBWebShop;
	}

	/// <summary>
	/// lägg till varje orderrad i ordern i databasens tabell
	///
	/// för varje sak, utgående från produktId (artikelnummer) skapa ett
	/// objekt för detta
	/// </summary>
	/// <param name="order"></param>
	/// <param name="orderItems"></param>
	public void SetOrderItems(Order order, List<OrderItem> orderItems)
	{
	    if (orderItems != null)
	    {
		foreach (OrderItem orderItem in orderItems)
		{
		    var newProduct = _dBWebShop.Product.FirstOrDefault(
			p => p.ProductId == orderItem.ProductId);
		    order.OrderItems.Add(new OrderItem
		    {
				Order = order,
				Product = newProduct,
				Quantity = orderItem.Quantity
		    });
		}
	    }
	}

	/// <summary>
	/// Utgående från en CreateOrderViewModel, skapa ordern i databasen
	/// </summary>
	/// <param name="createOrder"></param>
	public Order Create(CreateOrderViewModel createOrder)
	{
	    Order order = new Order();
	    order.OrderDate = DateTime.Now;
	    order.OrderItems = new List<OrderItem>();
	    SetOrderItems(order, createOrder.OrderItems);

	    _dBWebShop.Add(order);
	    _dBWebShop.SaveChanges();
			return order;
	}

	/// <summary>
	/// hämta ut orderitems dvs raderna i en order/(alla ordrar ?)
	/// </summary>
	/// <returns></returns>
	public List<OrderItem> Read()
	{
	    OrderItems = _dBWebShop.OrderItem.Include(o => o.Order).ToList();
	    OrderItems = _dBWebShop.OrderItem.Include(p => p.Product).ToList();

	    return OrderItems;
	}

	/// <summary>
	/// modifiering av en viss order
	/// ersätter Edit i IOrderItem ?
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
	    return _dBWebShop.Order.Include(o => o.OrderItems).FirstOrDefault(x => x.OrderId == Id);
	}

	/// <summary>
	/// borttagning av en viss order i databasen ?
	/// </summary>
	/// <param name="Id"></param>
	/// <returns></returns>
	public void Delete(int Id)
	{
	    Order OrderToDelete = FindById(Id);
	    _dBWebShop.Remove(OrderToDelete);
	    _dBWebShop.SaveChanges();
	}
    }
}
