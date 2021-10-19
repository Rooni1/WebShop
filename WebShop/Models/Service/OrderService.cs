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
        public OrderService(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
                
        }
        public void Add(CreateOrderViewModel createOrder)
        {
            _orderRepo.Create(createOrder);
        }

        public List<OrderItem> All()
        {
            return _orderRepo.Read();

        }

        public void Edit(int id, UpdateOrderViewModel updateOrder)
        {
           
            _orderRepo.Edit(id, updateOrder);
        }

        public Order FindBy(int id)
        {
            return _orderRepo.FindById(id);
            
        }

        public void Remove(int id)
        {
            _orderRepo.Delete(id);
        }
    }
}
