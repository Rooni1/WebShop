using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set;  }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public float ProductLength { get; set; }
        public float ProductDimension  { get; set; }
        public float ProductPrice { get; set; }
       

    }
}
