using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebShop.Models.Entities;
using WebShop.ViewModels;

namespace WebShop.Models.Repo
{
    public interface IProductRepo
    {
        void Create(CreateProductViewModel createProductVM);        
        List<Product> Read();
        // List<Product> Read(Category cat);
        Product Read(int id);        
        void Update(Product product);
        void Delete(Product product);
    }
}
