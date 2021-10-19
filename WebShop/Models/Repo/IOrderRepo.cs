using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebShop.Models.Entities;
using WebShop.ViewModels;
using WebShop.Models.Repo;

namespace WebShop.Models.Repo
{
    public interface IOrderRepo
    {
	//
	// hur man får en varukorg att bli en order i systemet (databasen)
	//
	void Create(CreateOrderViewModel createOrder);

	//
	// sökning efter en viss order
	//
	public Order FindById(int Id);

	//
	// vilka order har en viss kund sedan tidigare
	//
	public List<Order> FindByCustomer(int CustomerId);
	public List<OrderItem> Read();

	//
	// modifiering av en viss order
	//
	// ersätter Edit i IOrderItem ?
	//
	public void Edit(int id, UpdateOrderViewModel updateOrder);

	///<summary>
	/// borttagning av en order
	///</summary>
	public void Delete(int Id);
    }
}
