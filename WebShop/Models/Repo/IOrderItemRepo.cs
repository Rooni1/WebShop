using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebShop.Models.Entities;

namespace WebShop.Models.Repo
{
    public interface IOrderItemRepo
    {
        public OrderItem Create(Product whichArticle, int quantity);
        public OrderItem FindById(int Id);
        public List<OrderItem> FindByCustomer(int CustomerId);
        public List<OrderItem> FindByOrder(int orderId);        
        public OrderItem Edit(int Id);
    }
}
