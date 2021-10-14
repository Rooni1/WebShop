using WebShop.ViewModels;
using System.Collections.Generic;

namespace WebShop.Services
{
    public class ProductService : IProductService
    {
        public void Add(CreateProductViewModel product)
        {
        }

        public List<ProductViewModel> All()
        {
            return new List<ProductViewModel>();
        }

        public ProductViewModel FindBy(int id)
        {
            return new ProductViewModel();
        }

        public void Edit(int id, UpdateProductViewModel model)
        {
            
        }

        public void Remove(int id)
        {
            
        }
    }
}