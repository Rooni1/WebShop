using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebShop.Models.Entities;
using WebShop.Data;

namespace WebShop.Models.Repo
{
    public class OrderRepo : IOrderRepo
    {
       public OrderRepo() 
            {
            }
        
                  /// <summary>
        /// hur man får en varukorg att bli en order i systemet (databasen)
        /// </summary>
        /// <returns></returns>
        public Order Create()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// modifiering av en viss order
        ///  ersätter Edit i IOrderItem ?
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Order Edit(int Id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// vilka order har en viss kund sedan tidigare
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>        
        public List<Order> FindByCustomer(int CustomerId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// sökning efter en viss order
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>        
        public Order FindById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
