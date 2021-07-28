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
    public class LineItemRepoTest
    {
        private readonly DbContextOptions<StoreDBContext> _options;

        public LineItemRepoTest()
        {
            _options = new DbContextOptionsBuilder<StoreDBContext>().UseSqlite("Filename = Test.db").Options;
            this.Seed();
        }

        [Fact]
        public void AddLineItemShouldAddLineItem()
        {
            using (var context = new StoreDBContext(_options))
            {
                //Arrange
                ILineItemRepo repo = new LineItemRepo(context);
                LineItem item = new LineItem
                {
                    LineItemId = 3,
                    Quantity = 3
                };

                //Act
                repo.AddLineItem(item);
                LineItem check = repo.GetById(3);

                //Assert
                Assert.NotNull(check);
                Assert.Equal(item, check);
            }
        }
        [Fact]
        public void GetAllLineItemsShouldGetAllLineItems()
        {
            using (var context = new StoreDBContext(_options))
            {
                //Arange
                ILineItemRepo repo = new LineItemRepo(context);
                List<LineItem> products;

                //Act
                products = repo.GetAllLineItems();

                //Assert
                Assert.NotNull(products);
                Assert.Equal(2, products.Count);

            }
        }

        [Fact]
        public void UpdateShouldChangeLineItemInDatabase()
        {
            using (var context = new StoreDBContext(_options))
            {
                //Arrange
                ILineItemRepo repo = new LineItemRepo(context);
                LineItem tryUpdate = repo.GetById(1);

                //Act
                tryUpdate.Quantity = 6;
                repo.Update(tryUpdate);

                //Assert
                tryUpdate = repo.GetById(1);
                Assert.Equal(6, tryUpdate.Quantity);
            }
        }

        [Fact]
        public void GetByIdShouldGetSpecificLineItem()
        {
            using (var context = new StoreDBContext(_options))
            {
                //Arrange
                ILineItemRepo repo = new LineItemRepo(context);
                int findById = 1;
                LineItem found = new LineItem();

                //Act
                found = repo.GetById(findById);

                //Assert
                Assert.NotNull(found);
                Assert.Equal(found.LineItemId, findById);
            }
        }

        private void Seed()
        {
            using (var context = new StoreDBContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.LineItems.AddRange(
                    new LineItem
                    {
                        LineItemId = 1,
                        Quantity = 1
                    },
                    new LineItem
                    {
                        LineItemId = 2,
                        Quantity = 2
                    }
                );

                context.SaveChanges();
            }
        }
    }
}