//
// Time-stamp: <2021-10-31 17:03:26 stefan>
//

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models.Entities
{
    public class OrderItem
    {
	public int ProductId { get; set; }
	public Product Product { get; set; }
	public int OrderId { get; set; }
	public Order Order { get; set; }
	public int Quantity { get; set; }
    }
}
