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
        public void Add(CreateProductViewModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductViewModel> All()
        {
            List<ProductViewModel> products = new List<ProductViewModel>();
            ProductViewModel product = new ProductViewModel { id = "1", name = "Gunnebo" };
            products.Add(product);

            return products;
        }

        public void Edit(int id, UpdateProductViewModel product)
        {
        }

        public ProductViewModel FindBy(int id)
        {
            return new ProductViewModel();
        }

        public void Remove(int id)
        {
            
        }
    }
}
