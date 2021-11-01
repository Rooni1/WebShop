//
// Time-stamp: <2021-10-31 18:26:18 stefan>
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
	    // så här ?
	    // Order newOrder = new Order()
	    // {
	    //	//OrderId = createOrder.OrderId,
	    //	OrderDate = createOrder.OrderDate
	    // };
	    // _dBWebShop.Add(newOrder);
	    // foreach (OrderItem orderItem in createOrder.OrderItems)
	    //     _dBWebShop.Add(new OrderItem
	    //     {
	    //         OrderId = newOrder.OrderId,
	    //         ProductId = orderItem.ProductId,
	    //         Quantity = orderItem.Quantity
	    //     });
	    //
	    // väntar med SaveChanges tills att hela ordern är adderad, därefter SaveChanges (COMMIT)
	    // _dBWebShop.SaveChanges();
	    // Commit-tid
	    // Märk
	    // Funderar på vad som händer om något är fel i orderitem (specifikt ickeexisterane nyckel/productid
	    // inuti manifestet exv.)
	    // Det borde innebära att commit inte går igenom därför att dbcontext.add falerar (brott
	    // mot kravet/constraint att det ska existera en produkt med rätt ProduktId)

	    Order newOrder = new Order()
	    {
		OrderDate = DateTime.Now,
		OrderItems = new List<OrderItem>()
	    };
	    SetOrderItems(newOrder, createOrder.OrderItems);

	    _dBWebShop.Add(newOrder);
	    _dBWebShop.SaveChanges();

	    return newOrder;
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
