//
// Time-stamp: <2021-10-31 18:01:19 stefan>
//

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models.Entities;

namespace WebShop.ViewModels
{
    public class ProductViewModel
    {
	public string id { get; set; }
	public string name { get; set; }
	public string ProductDescription { get; set; }

	public float ProductLength { get; set; }

	public float ProductDimension { get; set; }
	public float ProductPrice { get; set; }
    }
}
