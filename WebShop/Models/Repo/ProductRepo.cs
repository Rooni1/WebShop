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

	/// <summary>
	/// ny artikel i databasen
	/// </summary>
	/// <param name="createProductVM"></param>
	/// <returns></returns>
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
	    _dBWebShop.SaveChanges();
	}

	/// <summary>
	/// borttagning av en viss artikel ur databasen
	/// </summary>
	/// <param name="product"></param>
	/// <returns></returns>
	public void Delete(Product product)
	{
	    _dBWebShop.Remove(product);
	    _dBWebShop.SaveChanges();

	}

	/// <summary>
	/// sortimentslista
	/// </summary>
	/// <returns></returns>
	public List<Product> Read()
	{
	    return products = _dBWebShop.Product.ToList();
	}

	/// <summary>
	/// sökning efter en viss produkt
	/// </summary>
	/// <param name="id"></param>
	/// <returns>Product</returns>
	public Product Read(int id)
	{
	    return _dBWebShop.Product.FirstOrDefault(x => x.ProductId == id);
	}

	/// <summary>
	/// sökning efter en viss order
	/// </summary>
	/// <param name="product"></param>
	/// <returns></returns>
	public void Update(Product product)
	{
	    _dBWebShop.Update(product);
	    _dBWebShop.SaveChanges();
	}
    }
}
