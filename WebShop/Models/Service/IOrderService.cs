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
        /**void Add(CreateOrderViewModel createorder);
        List<OrderItem> All();
        Order FindBy(int id);
        void Edit(int id, UpdateOrderViewModel updateOrder);**/
        void Remove(int id);
    }
}
