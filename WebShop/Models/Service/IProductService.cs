using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models.Entities;
using WebShop.ViewModels;

namespace WebShop.Models.Service
{
    public interface IProductService
    {
        Product Add(CreateProductViewModel createProductVM);
        ProductViewModel All();
        ProductViewModel FindBy(ProductViewModel search);
        Product FindBy(int id);
        Product Edit(int id, Product product);
        bool Remove(int id);
    }
}
