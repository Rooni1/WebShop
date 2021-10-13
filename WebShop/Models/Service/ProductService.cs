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
            return new List<ProductViewModel>();
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
