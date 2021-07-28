using Microsoft.EntityFrameworkCore;
using StoreDL;
using System;
using Xunit;
using Moq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using StoreModels;

namespace StoreTest
{
    public class ProductRepoTest
    {
        private readonly DbContextOptions<StoreDBContext> _options;

        public ProductRepoTest()
        {
            _options = new DbContextOptionsBuilder<StoreDBContext>().UseSqlite("Filename = Test.db").Options;
            this.Seed();
        }

        [Fact]
        public void AddProductShouldAddProduct()
        {
            using (var context = new StoreDBContext(_options))
            {
                //Arrange
                IProductRepo repo = new ProductRepo(context);
                Product prod = new Product
                {
                    ProductId = 3,
                    Name = "Big Die"
                };

                //Act
                repo.AddProduct(prod);
                Product check = repo.GetById(3);

                //Assert
                Assert.NotNull(check);
                Assert.Equal(prod, check);
            }
        }
        [Fact]
        public void GetAllProductsShouldGetAllProducts()
        {
            using (var context = new StoreDBContext(_options))
            {
                //Arange
                IProductRepo repo = new ProductRepo(context);
                List<Product> products;

                //Act
                products = repo.GetAllProducts();

                //Assert
                Assert.NotNull(products);
                Assert.Equal(2, products.Count);

            }
        }

        [Fact]
        public void UpdateShouldChangeProductInDatabase()
        {
            using (var context = new StoreDBContext(_options))
            {
                //Arrange
                IProductRepo repo = new ProductRepo(context);
                Product tryUpdate = repo.GetById(1);

                //Act
                tryUpdate.Name = "New Die";
                repo.Update(tryUpdate);

                //Assert
                tryUpdate = repo.GetById(1);
                Assert.Equal("New Die", tryUpdate.Name);
            }
        }

        [Fact]
        public void GetByIdShouldGetSpecificProduct()
        {
            using (var context = new StoreDBContext(_options))
            {
                //Arrange
                IProductRepo repo = new ProductRepo(context);
                int findById = 1;
                Product found = new Product();

                //Act
                found = repo.GetById(findById);

                //Assert
                Assert.NotNull(found);
                Assert.Equal(found.ProductId, findById);
            }
        }

        private void Seed()
        {
            using (var context = new StoreDBContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Products.AddRange(
                    new Product
                    {
                        ProductId = 1,
                        Name = "Die",
                    },
                    new Product
                    {
                        ProductId = 2,
                        Name = "2-Sided Die"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}