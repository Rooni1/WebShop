using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models.Entities;

/// <summary>
/// Vissa av operatorerna är överflödiga
/// </summary>
/// 
namespace WebShop.Models.Repo
{
    public interface IOrderItemRepo
    {
        public OrderItem Create();

        public OrderItem FindById(int Id);
        
        //
        // utgående från en viss order - returnerar de till den tillhörande orderraderina (OrderItem exv 10 st
        // rostfria insexskruvar M8 läng 45 mm )
        //
        public List<OrderItem> FindByCustomer(int CustomerId);

        ///
        /// <summary>
        /// förändring av en orderrad (OrderItem) efter att orden är accepterad och lagd
        /// implementeras i OrderRepo:s edit-funktion
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        //
        public OrderItem Edit(int Id);
    }
}
