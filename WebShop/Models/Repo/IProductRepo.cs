//
// Time-stamp: <2021-10-31 17:07:48 stefan>
//

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
	Product Create(CreateProductViewModel createProductVM);

	/// <summary>
	/// Uthämtning av sortimentslista
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

	/// <summary>
	///  pris ?
	///  ska den spärras för order ?
	/// </summary>
	/// <param name="product">
	/// Product - en instans av den produkt som ska modifieras
	/// </param>
	/// <returns>
	/// </returns>
	///
	void Update(Product product);

	/// <summary>
	/// borttagning av en viss produkt
	/// </summary>
	/// <param name="product"></param>
	void Delete(Product product);
    }
}
