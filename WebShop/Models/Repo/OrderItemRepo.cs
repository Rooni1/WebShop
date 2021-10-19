using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebShop.Models.Entities;
using WebShop.Data;

/// <summary>
/// Vissa av operatorerna är överflödiga
/// </summary>
/// 
namespace WebShop.Models.Repo
{
    public class OrderItemRepo : IOrderItemRepo
    {
           /// <summary>
        /// inläggning av ordrar - vilken produkt och hur många
        /// </summary>
        /// <param name="whichArticle"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public OrderItem Create(Product whichProduct, int quantity)
        {
            OrderItem newItem = new OrderItem();

            return newItem;
        }
        
        /// <summary>
        /// utgående från en viss order - returnerar de till den tillhörande orderraderna (OrderItem exv 10 st
        /// rostfria insexskruvar M8 läng 45 mm )
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        ///
        /// 
        public List<OrderItem> FindByOrder(int OrderId)
        {
            throw new NotImplementedException();
        }
       /// 
             /// <summary>
        /// hitta en viss orderrad i en viss order
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
   
                /// <summary>
        /// utgående från en viss kund - returnerar den kundens orderrader (OrderItem exv 10 st
        /// rostfria insexskruvar M8 läng 45 mm )
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        public List<OrderItem> FindByCustomer(OrderId id)
        {
            throw new NotImplementedException();
        }

                /// <summary>
        /// hitta en viss orderrad i en viss order
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>

        public OrderItem FindById(int Id)
        {
            throw new NotImplementedException();
        }             

        ///
        /// <summary>
        /// förändring av en orderrad (OrderItem) efter att orden är accepterad och lagd
        /// implementeras i OrderRepo:s edit-funktion. 
        /// 
        /// Vad ska kunna göras ?
        ///    Antalet (kvantitet) ?  
        ///    Vilken produkt ?
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public OrderItem Edit(int Id)
        {
            throw new NotImplementedException();
        }

    }
}
