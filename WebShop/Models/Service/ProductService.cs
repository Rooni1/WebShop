﻿using System;
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
            _productRepo = productRepo;

        }
        public void Add(CreateProductViewModel product)
        {
            _productRepo.Create(product);
        }

        public List<ProductViewModel> All()
        {
            //List<ProductViewModel> products = new List<ProductViewModel>();
            //ProductViewModel product = new ProductViewModel { id = "1", name = "Gunnebo" };
            List<Product> entities = _productRepo.Read();
            List<ProductViewModel> products = new List<ProductViewModel>();
            foreach(Product entity in entities)
            {
                ProductViewModel product = new ProductViewModel { 
                    id = entity.ProductId.ToString(), 
                    name = entity.ProductName,
                    ProductDescription = entity.ProductDescription,
                    ProductLength = entity.ProductLength,
                    ProductDimension = entity.ProductDimension,
                    ProductPrice = entity.ProductPrice
                };
                products.Add(product);
            }

            return products;
        }

        public void Edit(int id, UpdateProductViewModel product)
        {
            Product productToUpdate = _productRepo.Read(id);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.ProductDescription = product.ProductDescription;
            productToUpdate.ProductLength = product.ProductLength;
            productToUpdate.ProductDimension = product.ProductDimension;
            productToUpdate.ProductPrice = product.ProductPrice;
            _productRepo.Update(productToUpdate);
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
