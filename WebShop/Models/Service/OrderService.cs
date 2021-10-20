using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models.Entities;
using WebShop.Models.Repo;
using WebShop.ViewModels;

namespace WebShop.Models.Service
{
    public class OrderService : IOrderService
    {
	private readonly IOrderRepo _orderRepo;

	/// <summary>
	///
	/// </summary>
	/// <param name="orderRepo"></param>
	public OrderService(IOrderRepo orderRepo)
	{
	    _orderRepo = orderRepo;

	}

	/// <summary>
	///
	/// </summary>
	/// <param name="createOrder"></param>
	public void Add(CreateOrderViewModel createOrder)
	{
	    _orderRepo.Create(createOrder);
	}

	/// <summary>
	///
	/// </summary>
	/// <returns></returns>
	public List<OrderItem> All()
	{
	    return _orderRepo.Read();

	}

	/// <summary>
	///
	/// </summary>
	/// <param name="id"></param>
	/// <param name="updateOrder"></param>
	public void Edit(int id, UpdateOrderViewModel updateOrder)
	{

	    _orderRepo.Edit(id, updateOrder);
	}

	/// <summary>
	///
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	public Order FindBy(int id)
	{
	    return _orderRepo.FindById(id);

	}

	/// <summary>
	///
	/// </summary>
	/// <param name="id"></param>
	public void Remove(int id)
	{
	    _orderRepo.Delete(id);
	}
    }
}
