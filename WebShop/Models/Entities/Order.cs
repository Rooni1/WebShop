//
// Time-stamp: <2021-10-19 13:53:44 stefan>
//

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models.Entities
{
    public class Order
    {
	[Key]
	public int OrderId { get; set; }
	public DateTime OrderDate { get; set; }
	public List<OrderItem> OrderItems { get; set; }
    }
}
