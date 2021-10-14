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
        void Add(CreateProductViewModel product);
        List<ProductViewModel> All();
        ProductViewModel FindBy(int id);
        void Edit(int id, UpdateProductViewModel product);
        void Remove(int id);
    }
}
