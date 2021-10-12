using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models.Entities;
using WebShop.ViewModels;

namespace WebShop.Models.Service
{
    public class ProductService : IProductService
    {
        public Product Add(CreateProductViewModel createProductVM)
        {
            throw new NotImplementedException();
        }

        public ProductViewModel All()
        {
            throw new NotImplementedException();
        }

        public Product Edit(int id, Product product)
        {
            throw new NotImplementedException();
        }

        public ProductViewModel FindBy(ProductViewModel search)
        {
            throw new NotImplementedException();
        }

        public Product FindBy(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
