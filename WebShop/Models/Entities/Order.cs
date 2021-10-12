using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models.Entities
{
    public class Order
    {
        
        public int OrderId { get; set; } // This should be the primary key.

        //public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItem> OrderItems { get; set; }

    }
}
