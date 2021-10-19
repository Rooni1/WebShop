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
        /// <summary>
        /// Inläggning av nya produkter i sortimentet
        /// </summary>
        /// <param name="createProductVM"></param>
        void Create(CreateProductViewModel createProductVM);        

        /// <summary>
        /// Uthämtning av sortimentslista
        /// </summary>
        /// <returns></returns>
        List<Product> Read();

        
        Product Read(int id);        
        void Update(Product product);
        void Delete(Product product);
    }
}
