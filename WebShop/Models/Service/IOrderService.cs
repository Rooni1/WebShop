//
// Time-stamp: <2021-10-31 17:41:22 stefan>
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebShop.Models.Entities;
using WebShop.ViewModels;

namespace WebShop.Models.Service
{
    public interface IOrderService
    {
	Order Add(CreateOrderViewModel createorder);
	List<OrderItem> All();
	Order FindBy(int id);
	void Edit(int id, UpdateOrderViewModel updateOrder);
	void Remove(int id);
    }
}
