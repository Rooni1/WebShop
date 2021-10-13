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
        private readonly ProductRepo _productRepo;
        public ProductService(ProductRepo productRepo)
        {
            productRepo = _productRepo;

        }
        public void Add(CreateProductViewModel product)
        {
            _productRepo.Create(product);
        }

        public ProductViewModel All()
        {
            ProductViewModel productVVM = new ProductViewModel { products = _productRepo.Read() };
            return productVVM;
        }

        public void Edit(int id, UpdateProductViewModel product)
        {
            throw new NotImplementedException();
        }

        public Product FindBy(int id)
        {
            return _productRepo.Read(id);
        }

        public void Remove(int id)
        {
            Product productToRemove = _productRepo.Read(id);
            _productRepo.Delete(productToRemove);
        }
    }
}
