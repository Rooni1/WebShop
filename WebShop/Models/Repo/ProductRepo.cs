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
	// de här variablerna i modulen, behövs de ?
	// i funktionerna där den används, där kan man ha en lokal
	// variabel för den eller ev som List, returnera dbWebShop.Product.ToList direkt
	private static List<Product> products = new List<Product>();
	public ProductRepo(DBWebShop dBWebShop)
	{
	    _dBWebShop = dBWebShop;
	}


	/// <summary>
	///
	/// </summary>
	/// <param name="createProductVM"></param>
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

	/// <summary>
	///
	/// </summary>
	/// <param name="product"></param>
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
	    //return products = _dBWebShop.Product.ToList();

	     return _dBWebShop.Product.ToList();
	}

	/// <summary>
	/// Uppgifter om en viss artikel
	/// </summary>
	/// <param name="id"></param>
	/// <returns>
	/// Product - en instans av den artikel det gäller
	/// </returns>
	public Product Read(int id)
	{
	    return _dBWebShop.Product.FirstOrDefault(x => x.ProductId == id);
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
