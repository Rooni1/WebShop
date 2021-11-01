//
// Time-stamp: <2021-10-31 18:01:54 stefan>
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models.Entities;

namespace WebShop.ViewModels
{
    public class UpdateOrderViewModel
    {
	public int OrderId { get; set; }
	public DateTime OrderDate { get; set; }
	public List<OrderItem> OrderItems = new List<OrderItem>();
    }
}
