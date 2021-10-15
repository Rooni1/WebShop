using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Data;
using WebShop.Models.Entities;
using WebShop.ViewModels;

namespace WebShop.Models.Repo
{
    public class ProductRepo : IProductRepo
    {
        private readonly DBWebShop _dBWebShop;
        private static List<Product> products = new List<Product>();
        public ProductRepo(DBWebShop dBWebShop)
        {
            _dBWebShop = dBWebShop;
        }
        public void Create(CreateProductViewModel createProductVM)
        {
            Product newProduct = new Product
            {
                ProductName = createProductVM.ProductName,
                ProductDescription = createProductVM.ProductDescription,
                ProductDimension = createProductVM.ProductDimension,
                ProductLength = createProductVM.ProductLength,
                ProductPrice = createProductVM.ProductPrice
                
            };
            _dBWebShop.Add(newProduct);
            _dBWebShop.SaveChanges();
            
        }

        public void Delete(Product product)
        {
            _dBWebShop.Remove(product);
            _dBWebShop.SaveChanges();
           
        }

        public List<Product> Read()
        {
            return products = _dBWebShop.Product.ToList();
        }

        public Product Read(int id)
        {
            products = _dBWebShop.Product.ToList();
            
            foreach (Product item in products)
            {
                if (item.ProductId == id)
                {
                    return item;
                }
            }
            return null;
        }

        public void Update(Product product)
        {
            _dBWebShop.Update(product);
            _dBWebShop.SaveChanges();
        }
    }
}
