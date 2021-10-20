using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.ViewModels;

namespace WebShop.Models.Service
{
    public interface IOrderService
    {
        /**void Add(CreateOrderViewModel createorder);
        List<OrderViewModel> All();
        OrderViewModel FindBy(int id);
        void Edit(int id, UpdateOrderViewModel updateOrder);**/
        void Remove(int id);
    }
}
