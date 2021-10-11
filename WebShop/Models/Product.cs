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
        public string ProductSize { get; set; }
        public int ProductQuantity { get; set; }
        public float ProductPrice { get; set; }
        public double ArticleNumber { get; set; }

    }
}
