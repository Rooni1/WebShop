using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebShop.Models.Entities;

namespace WebShop.Models.Repo
{
    public interface IOrderRepo
    {
        public Order Create();
    public Order FindById(int Id);
        public List<Order> FindByCustomer(int CustomerId);
              public Order Edit(int Id);
    }
}
