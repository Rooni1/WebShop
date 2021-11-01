//
// Time-stamp: <2021-10-31 17:57:57 stefan>
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebShop.Models.Entities;

namespace WebShop.ViewModels
{
    public class CreateOrderViewModel
    {
	public int OrderId { get; set; }
	public DateTime OrderDate { get; set; }
	public List<OrderItem> OrderItems { get; set; }

    }
}
