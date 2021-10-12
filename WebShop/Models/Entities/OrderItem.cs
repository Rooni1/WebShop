using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models.Entities
{
    public class OrderItem
    {
        [Key]
        public  int OrderItemId { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }


    }
}
