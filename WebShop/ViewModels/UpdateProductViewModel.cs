//
// Time-stamp: <2021-10-31 18:02:27 stefan>
//

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.ViewModels
{
    public class UpdateProductViewModel
    {

	[Required]
	[MaxLength(50)]
	public string ProductName { get; set; }
	[Required]
	public string ProductDescription { get; set; }
	[Required]
	public float ProductLength { get; set; }
	[Required]
	public float ProductDimension { get; set; }
	[Required]
	public float ProductPrice { get; set; }

    }
}
