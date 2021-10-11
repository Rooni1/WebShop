using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class Product
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public float ProductLength { get; set; }
        public float ProductDimension  { get; set; }
        public int ProductQuantity { get; set; }
        public float ProductPrice { get; set; }
        public int ArticleNumber { get; set; }

    }
}
