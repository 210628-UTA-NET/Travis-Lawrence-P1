using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreModels;
using Xunit;

namespace StoreTest
{
    public class CustomerModelTest
    {
        [Fact]
        public void CustomerShouldSetValidData()
        {
            //Arrange
            Customer test = new Customer();
            int testId = 4;
            String testName = "Jacob";
            String testAddress = "Jacob's House";
            String testEmail = "jacob@jacob.jacob";
            long testPhoneNumber = 1234567890;
            List<Order> testOrders = new List<Order>
            {
                new Order(){OrderId=1},
                new Order(){OrderId=2}
            };

            //Act
            test.CustomerId = testId;
            test.Name = testName;
            test.Address = testAddress;
            test.Email = testEmail;
            test.PhoneNumber = testPhoneNumber;
            test.Orders = testOrders;

            //Assert
            Assert.Equal(testId, test.CustomerId);
            Assert.Equal(testName, test.Name);
            Assert.Equal(testAddress, test.Address);
            Assert.Equal(testEmail, test.Email);
            Assert.Equal(testPhoneNumber, test.PhoneNumber);
            Assert.Equal(testOrders, test.Orders);
        }
    }
}
