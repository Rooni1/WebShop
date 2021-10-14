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

        /// <summary>
        /// Dyr funktion - alla produkter i databasen
        /// </summary>
        /// <returns>
        /// en lista med instanser
        /// </returns>
        List<Product> Read();

        /// <summary>
        /// Uppgifter om en viss artikel
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Product - en instans av den artikel det gäller
        /// </returns>
        Product Read(int id);

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
        Product Update(Product product);
        void Delete(Product product);
    }
}
