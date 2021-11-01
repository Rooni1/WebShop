//
// Time-stamp: <2021-10-31 17:07:05 stefan>
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebShop.Models.Entities;
using WebShop.ViewModels;

namespace WebShop.Models.Repo
{
    public interface IOrderRepo
    {
	/// <summary>
	/// hur man får en varukorg att bli en order i systemet (databasen)
	/// </summary>
	/// <param name="createOrder"></param>
	Order Create(CreateOrderViewModel createOrder);

	/// <summary>
	/// sökning efter en viss order
	/// </summary>
	/// <param name="Id"></param>
	/// <returns></returns>
	public Order FindById(int Id);

	/// <summary>
	/// vilka order har en viss kund sedan tidigare
	/// </summary>
	/// <param name="CustomerId"></param>
	/// <returns></returns>
	public List<Order> FindByCustomer(int CustomerId);

	/// <summary>
	///
	/// </summary>
	/// <returns></returns>
	public List<OrderItem> Read();

	/// <summary>
	/// modifiering av en viss order
	/// ersätter Edit i IOrderItem ?
	/// </summary>
	/// <param name="id"></param>
	/// <param name="updateOrder"></param>
	public void Edit(int id, UpdateOrderViewModel updateOrder);

	/// <summary>
	/// borttagning av en order
	/// </summary>
	/// <param name="Id"></param>
	public void Delete(int Id);
    }
}
