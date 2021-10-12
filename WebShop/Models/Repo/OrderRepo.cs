using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models.Entities;

namespace WebShop.Models.Repo
{
    public class OrderRepo : IOrderRepo
    {
        public Order Create()
        {
            throw new NotImplementedException();
        }

        public Order Edit(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Order> FindByCustomer(int CustomerId)
        {
            throw new NotImplementedException();
        }

        public Order FindById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
