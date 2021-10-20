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

	//
	// globala listor i modulen, varför ?
	//
	List<OrderItem> OrderItems = new List<OrderItem>();
	List<Order> orders = new List<Order>();
	public OrderRepo(DBWebShop dBWebShop)
	{
	    _dBWebShop = dBWebShop;
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="createOrder"></param>
	public void Create(CreateOrderViewModel createOrder)
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
		//OrderId = createOrder.OrderId,
		OrderDate = createOrder.OrderDate
	    };
	    _dBWebShop.Add(newOrder);
	    _dBWebShop.SaveChanges();
	    for (int i = 0; i < createOrder.OrderItems.Count;  i++)
	    {
		OrderItem itemsOrdered = new OrderItem
		{
		    OrderId = newOrder.OrderId,
		    Quantity = createOrder.OrderItems[i].Quantity,
		    ProductId = createOrder.OrderItems[i].ProductId

		};

		_dBWebShop.Add(itemsOrdered);
		_dBWebShop.SaveChanges();
	    }
	}

	/// <summary>
	/// vad ska den göra ?
	/// </summary>
	/// <returns></returns>
	// public List<OrderItem> Read()
	// {
	//     List<OrderItem> orderItems = new List<OrderItem>();
	//     orderItems = _dBWebShop.OrderItem.Include(o => o.Order).ToList();
	//     orderItems = _dBWebShop.OrderItem.Include(p => p.Product).ToList();
	//     return orderItems;
	// }
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
	    //
	    // man behöver inte iterera igenom alla ordrar självt, låt databasen få göra sitt jobb
	    // detta bör bli en 'select * from order where orderid = xxxxx;'
	    //
	    // Order bör orderid som index (nödvändigt därför att order särskiljs på sitt ID
	    // och operationen för att addera en rad i databasen tar näst intill konstant tid om
	    // det finns ett index som man kan kontrollera för att se om något redan finns.)
	    //
	    // orders = _dBWebShop.Order.ToList();
	    //
	    // foreach (Order item in orders)
	    // {
	    //     if (item.OrderId == Id)
	    //     {
	    //         return item;
	    //     }
	    // }
	    // return null;

	    return _dBWebShop.Order.Single(order => order.OrderId == Id);
	}

	public void Delete(int Id)
	{
	    Order OrderToDelete = FindById(Id);
	    _dBWebShop.Remove(OrderToDelete);
	    _dBWebShop.SaveChanges();
	}
    }
}
