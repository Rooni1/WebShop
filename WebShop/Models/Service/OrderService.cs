using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models.Repo;
using WebShop.ViewModels;

namespace WebShop.Models.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _orderRepo;
        public OrderService(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
                
        }
        /**public void Add(CreateOrderViewModel createOrder)
        {
            _orderRepo.Create(createOrder);
        }

        public List<OrderViewModel> All()
        {
            throw new NotImplementedException();
        }

        public void Edit(int id, UpdateOrderViewModel updateOrder)
        {
            throw new NotImplementedException();
        }

        public OrderViewModel FindBy(int id)
        {
            throw new NotImplementedException();
        }**/

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
