using Moq;
using System;
using System.Collections.Generic;
using WebShop.Models.Entities;
using WebShop.Models.Repo;
using WebShop.Models.Service;
using WebShop.ViewModels;
using Xunit;

namespace WebShopTest
{
    public class ProductTest
    {
        private readonly ProductService _testProductService;
        private readonly Mock<IProductRepo> _productrepoMock = new Mock<IProductRepo>();
        public ProductTest()
        {
            _testProductService = new ProductService(_productrepoMock.Object);
        }
        [Fact]
        public void GetProductByIdTest()
        {
            //Arrange
            int productId = 4;
            string productName = "Bult";
            var expectedproduct = new Product
            {
                ProductId = productId,
                ProductName = productName,
                ProductDescription = "rostfri",
                ProductDimension  = 8,
                ProductLength = 3,
                ProductPrice = 20
            };

            _productrepoMock.Setup(x => x.Read(productId)).Returns(expectedproduct);
            //Act
            var actualProduct = _testProductService.FindBy(productId);
            //Assert
            Assert.Equal(productId.ToString(), actualProduct.id);
            Assert.Equal(productName, actualProduct.name);
        }

        [Fact]
        public void CreateProductTest()
        {
            //Arrange
            string productId = "4";
            string productName = "Bult";
            var expectedproduct = new CreateProductViewModel();
            
            expectedproduct.id = productId;
            expectedproduct.ProductName = productName;
            expectedproduct.ProductDescription = "rostfri";
            expectedproduct.ProductDimension = 8;
            expectedproduct.ProductLength = 3;
            expectedproduct.ProductPrice = 10;

            var newExpectedProduct = new Product
            {
                ProductId = Convert.ToInt32(productId),
                ProductName = expectedproduct.ProductName,
                ProductDescription= expectedproduct.ProductDescription,
                ProductDimension = expectedproduct.ProductDimension,
                ProductLength = expectedproduct.ProductLength,
                ProductPrice = expectedproduct.ProductPrice

            }; 


            _productrepoMock.Setup(x => x.Create(expectedproduct)).Returns(newExpectedProduct);
            //Act
            var actualProduct = _testProductService.Add(expectedproduct);
            //Assert
            Assert.Equal(newExpectedProduct.ProductId.ToString(), actualProduct.ProductId.ToString());
            Assert.Equal(newExpectedProduct.ProductName, actualProduct.ProductName);
        }

        [Fact]
        public void GetAllProductsTest()
        {
            //Arrange
            var products = CreateProductList();
            List<ProductViewModel> productVM = new List<ProductViewModel>();
            foreach (Product items in products)
            {
                ProductViewModel product = new ProductViewModel
                {
                    id = items.ProductId.ToString(),
                    name = items.ProductName,
                    ProductDescription = items.ProductDescription,
                    ProductLength = items.ProductLength,
                    ProductDimension = items.ProductDimension,
                    ProductPrice = items.ProductPrice
                };
                productVM.Add(product);
            }

            _productrepoMock.Setup(x => x.Read()).Returns(products);
            //Act
            var actualProducts = _testProductService.All();
            //Assert
            Assert.Equal(products.Count, actualProducts.Count);
            
        }

        public List<Product> CreateProductList()
        {
            List<Product> products = new List<Product>
            {

           
            new Product
            {
                ProductId = 2,
                ProductName = "Skruv",
                ProductDescription = "rostfri",
                ProductDimension = 8,
                ProductLength = 3,
                ProductPrice = 20
            },
                  
            new Product
            {
                ProductId = 5,
                ProductName = "Bult",
                ProductDescription = "Rund",
                ProductDimension = 9,
                ProductLength = 2,
                ProductPrice = 10
            },

             new Product
            {
                ProductId = 8,
                ProductName = "Spik",
                ProductDescription = "Rund rostfri",
                ProductDimension = 12,
                ProductLength = 5,
                ProductPrice = 25
            }


        };
            return products;
            
        }

    }
}
