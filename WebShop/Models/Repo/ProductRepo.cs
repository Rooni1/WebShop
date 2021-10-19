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
            _dBWebShop.SaveChanges();   // commit
            
        }

        public void Delete(Product product)
        {
            _dBWebShop.Remove(product);
            _dBWebShop.SaveChanges(); // commit
           
        }

        /// <summary>
        /// Dyr funktion - alla produkter i databasen
        /// </summary>
        /// <returns>
        /// en lista med instanser
        /// </returns>
        public List<Product> Read()
        {
            return products = _dBWebShop.Product.ToList();
        }
        
       
        /// <summary>
        /// alla produkter i en viss kategori (bult/skruv i mm, muttrar i mm, bult/skruv i tum, muttrar i tum, brickor)
        /// </summary>      
        //public List<Product> Read(DbLoggerCategory cat)
        //{
        //    throw new NotImplementedException();
        //}

        /// <summary>
        /// Uppgifter om en viss artikel
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Product - en instans av den artikel det gäller
        /// </returns>
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

        ///
        /// något med en viss artikel har ändrats ?
        /// <summary>
        ///  pris ?
        ///  ska den spärras för order ?
        /// </summary>
        /// <param name="product">
        /// Product - en instans av den produkt som ska modifieras
        /// </param>
        /// <returns>
        /// Product - modifierad instans
        /// </returns>
        /// 
        public void Update(Product product)
        {
            _dBWebShop.Update(product);
            _dBWebShop.SaveChanges();
        }
    }
}
