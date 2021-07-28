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
    public class LocationRepoTest
    {
        private readonly DbContextOptions<StoreDBContext> _options;

        public LocationRepoTest()
        {
            _options = new DbContextOptionsBuilder<StoreDBContext>().UseSqlite("Filename = Test.db").Options;
            this.Seed();
        }

        [Fact]
        public void GetAllLocationsShouldGetAllLocations()
        {
            using (var context = new StoreDBContext(_options))
            {
                //Arange
                ILocationRepo repo = new LocationRepo(context);
                List<Location> locations;

                //Act
                locations = repo.GetAllLocations();

                //Assert
                Assert.NotNull(locations);
                Assert.Equal(2, locations.Count);

            }
        }

        [Fact]
        public void GetInventoryShouldGetLocationInventory()
        {
            using(var context = new StoreDBContext(_options))
            {
                //Arrange
                ILocationRepo repo = new LocationRepo(context);
                List<LineItem> getInventory = new List<LineItem>();

                //Act
                getInventory = repo.GetInventory(1);

                //Assert
                Assert.NotNull(getInventory);
                Assert.Equal(2, getInventory.Count);
            }
        }

        [Fact]
        public void NameSearchShouldGetMatchingLocations()
        {
            using (var context = new StoreDBContext(_options))
            {
                //Arrange
                ILocationRepo repo = new LocationRepo(context);
                string findByName = "Test Store";
                List<Location> found = new List<Location>();

                //Act
                found = repo.NameSearch(findByName);

                //Assert
                Assert.NotNull(found);
                Assert.Single(found);
                Assert.Equal(found[0].Name, findByName);
            }
        }

        [Fact]
        public void UpdateShouldChangeLocationInDatabase()
        {
            using (var context = new StoreDBContext(_options))
            {
                //Arrange
                ILocationRepo repo = new LocationRepo(context);
                Location tryUpdate = repo.GetById(1);

                //Act
                tryUpdate.Name = "Test World";
                repo.Update(tryUpdate);

                //Assert
                tryUpdate = repo.GetById(1);
                Assert.Equal("Test World", tryUpdate.Name);
            }
        }

        [Fact]
        public void GetProductShouldGetSpecificProduct()
        {
            using (var context = new StoreDBContext(_options))
            {
                //Arrange
                ILocationRepo repo = new LocationRepo(context);
                int findById = 1;
                Product found = new Product();

                //Act
                found = repo.GetProduct(findById);

                //Assert
                Assert.NotNull(found);
                Assert.Equal(found.ProductId, findById);
            }
        }

        [Fact]
        public void GetByIdShouldGetSpecificLocation()
        {
            using (var context = new StoreDBContext(_options))
            {
                //Arrange
                ILocationRepo repo = new LocationRepo(context);
                int findById = 1;
                Location found = new Location();

                //Act
                found = repo.GetById(findById);

                //Assert
                Assert.NotNull(found);
                Assert.Equal(found.LocationId, findById);
            }
        }

        /*[Fact]
        public void GetOrdersShouldGetLocationOrders()
        {
            using (var context = new StoreDBContext(_options))
            {
                //Arrange
                ILocationRepo repo = new LocationRepo(context);
                List<Order> found = new List<Order>();

                //Act
                found = repo.GetOrders(1);

                //Assert
                Assert.NotNull(found);
                Assert.Equal(2, found.Count);
            }
        }*/

        private void Seed()
        {
            using (var context = new StoreDBContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Locations.AddRange(
                    new Location
                    {
                        LocationId = 1,
                        Name = "Test Store",
                        Address = "Test Road",
                        Inventory = new List<LineItem>
                        {
                            new LineItem(){LineItemId = 1},
                            new LineItem(){LineItemId = 2}
                        },
                        Orders = new List<Order>
                            {
                                new Order(){OrderId=1},
                                new Order(){OrderId=2}
                            }

                    },
                    new Location
                    {
                        LocationId = 2,
                        Name = "Test Mart",
                        Address = "Test Lane",
                        Inventory = new List<LineItem>
                        {
                            new LineItem(){LineItemId=3}
                        },
                        Orders = new List<Order>
                        {
                            new Order
                            {
                                OrderId = 3
                            },
                            new Order
                            {
                                OrderId = 4
                            }
                        }
                    }
                );

                context.Products.AddRange(
                    new Product
                    {
                        ProductId = 1
                    },
                    new Product
                    {
                        ProductId = 2
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
