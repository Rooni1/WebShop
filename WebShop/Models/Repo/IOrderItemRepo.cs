using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models.Entities;

namespace WebShop.Models.Repo
{
    public interface IOrderItemRepo
    {
        public OrderItem Create();

        public OrderItem FindById(int Id);

        public List<OrderItem> FindByCustomer(int CustomerId);
        public OrderItem Edit(int Id);

    }
}
