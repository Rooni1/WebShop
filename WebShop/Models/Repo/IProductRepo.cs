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
	/// <returns>
	/// en lista med instanser
	/// </returns>
	List<Product> Read();

	/// <summary>
	/// Uppgifter om en viss produkt
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	Product Read(int id);

	/// <summary>
	/// modifikation av läget för en viss produkt
	/// </summary>
	/// <param name="product"></param>
	void Update(Product product);

	/// <summary>
	/// borttagning av en viss produkt
	/// </summary>
	/// <param name="product"></param>
	void Delete(Product product);
    }
}
