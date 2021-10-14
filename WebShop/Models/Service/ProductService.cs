using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models.Entities;
using WebShop.Models.Repo;
using WebShop.ViewModels;

namespace WebShop.Models.Service
{
   
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;
        public ProductService(IProductRepo productRepo)
        {
            productRepo = _productRepo;

        }
        public void Add(CreateProductViewModel product)
        {
            _productRepo.Create(product);
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

            //return _productRepo.Read(id);

            return new ProductViewModel();

        }

        public void Remove(int id)
        {

            Product productToRemove = _productRepo.Read(id);
            _productRepo.Delete(productToRemove);

            

        }
    }
}
