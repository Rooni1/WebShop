using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models.Entities;

namespace WebShop.Models.Repo
{
    public class OrderItemRepo : IOrderItemRepo
    {
        public OrderItem Create()
        {
            throw new NotImplementedException();
        }

        public OrderItem Edit(int Id)
        {
            throw new NotImplementedException();
        }

        public List<OrderItem> FindByCustomer(int CustomerId)
        {
            throw new NotImplementedException();
        }

        public OrderItem FindById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
