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
    public class CustomerRepoTest
    {
        private readonly DbContextOptions<StoreDBContext> _options;

        public CustomerRepoTest()
        {
            _options = new DbContextOptionsBuilder<StoreDBContext>().UseSqlite("Filename = Test.db").Options;
            this.Seed();
        }

        [Fact]
        public void AddCustomerShouldAddCustomer()
        {
            using(var context = new StoreDBContext(_options))
            {
                //Arrange
                ICustomerRepo repo = new CustomerRepo(context);
                Customer cust = new Customer
                {
                    CustomerId = 3,
                    Name = "Jacob 2",
                    Address = "Other Jacob's House",
                    Email = "otherjacob@jacob.jacob",
                    PhoneNumber = 2223334445
                };

                //Act
                repo.AddCustomer(cust);
                Customer check = repo.GetById(3);

                //Assert
                Assert.NotNull(check);
                Assert.Equal(cust, check);
            }
        }

        [Fact]
        public void GetAllCustomersShouldGetAllCustomers()
        {
            using(var context = new StoreDBContext(_options))
            {
                //Arange
                ICustomerRepo repo = new CustomerRepo(context);
                List<Customer> customers;

                //Act
                customers = repo.GetAllCustomers();

                //Assert
                Assert.NotNull(customers);
                Assert.Equal(2, customers.Count);

            }
        }

        [Fact]
        public void NameSearchShouldGetMatchingCustomers()
        {
            using(var context = new StoreDBContext(_options))
            {
                //Arrange
                ICustomerRepo repo = new CustomerRepo(context);
                string findByName = "Jacob";
                List<Customer> found = new List<Customer>();

                //Act
                found = repo.NameSearch(findByName);

                //Assert
                Assert.NotNull(found);
                Assert.Single(found);
                Assert.Equal(found[0].Name, findByName);
            }
        }

        [Fact]
        public void UpdateShouldChangeCustomerInDatabase()
        {
            using(var context = new StoreDBContext(_options))
            {
                //Arrange
                ICustomerRepo repo = new CustomerRepo(context);
                Customer tryUpdate = repo.GetById(4);

                //Act
                tryUpdate.Name = "Lesser Jacob";
                repo.Update(tryUpdate);

                //Assert
                tryUpdate = repo.GetById(4);
                Assert.Equal("Lesser Jacob", tryUpdate.Name);
            }
        }

        [Fact]
        public void GetByIdShouldGetSpecificCustomer()
        {
            using(var context = new StoreDBContext(_options))
            {
                //Arrange
                ICustomerRepo repo = new CustomerRepo(context);
                int findById = 4;
                Customer found = new Customer();

                //Act
                found = repo.GetById(findById);

                //Assert
                Assert.NotNull(found);
                Assert.Equal(found.CustomerId, findById);
            }
        }

        /*[Fact]
        public void GetOrdersShouldGetCustomerOrders()
        {
            using(var context = new StoreDBContext(_options))
            {
                //Arrange
                ICustomerRepo repo = new CustomerRepo(context);
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

                context.Customers.AddRange(
                    new Customer
                    {
                        CustomerId = 4,
                        Name = "Jacob",
                        Address = "Jacob's House",
                        Email = "jacob@jacob.jacob",
                        PhoneNumber = 1234567890,
                        Orders = new List<Order>
                            {
                                new Order(){OrderId=1},
                                new Order(){OrderId=2}
                            }

                    },
                    new Customer
                    {
                        CustomerId = 5,
                        Name = "Travis",
                        Address = "Travis's House",
                        Email = "travis@travis.travis",
                        PhoneNumber = 0987654321,
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

                context.SaveChanges();
            }
        }
    }
}
