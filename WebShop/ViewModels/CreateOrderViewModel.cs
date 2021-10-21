using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models.Entities;

namespace WebShop.ViewModels
{
    public class CreateOrderViewModel
    {
        public List<OrderItem> OrderItems { get; set; }

    }
}
