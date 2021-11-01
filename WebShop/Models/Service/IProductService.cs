//
// Time-stamp: <2021-10-31 17:41:22 stefan>
//

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
	Product Add(CreateProductViewModel product);
	List<ProductViewModel> All();
	ProductViewModel FindBy(int id);
	void Edit(int id, UpdateProductViewModel product);
	void Remove(int id);
    }
}
