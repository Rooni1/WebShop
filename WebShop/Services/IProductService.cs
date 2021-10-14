using System.Collections.Generic;
using WebShop.ViewModels;

namespace WebShop.Services
{
    public interface IProductService
    {
        public void Add(CreateProductViewModel product);
        public List<ProductViewModel> All();
        public ProductViewModel FindBy(int id);
        public void Edit(int id, UpdateProductViewModel model);
        public void Remove(int id);
    }
}
