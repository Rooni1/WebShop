using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models.Entities;

namespace WebShop.ViewModels
{
    public class ProductViewModel
    {
        CreateProductViewModel CreateProductVM { get; set; }
        public List<Product> products = new List<Product>();
    }
}
