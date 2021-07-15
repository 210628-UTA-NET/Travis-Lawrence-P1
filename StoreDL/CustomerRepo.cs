using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using StoreModels;
using System.Linq;

namespace StoreDL
{
    public class CustomerRepo : ICustomerRepo
    {
        //private const string _filepath = "./../StoreDL/Databases/Customers.json";
        //private string _jsonString;
        private Entities.DemoDbContext _context;
        public CustomerRepo(Entities.DemoDbContext p_context){
            _context = p_context;
        }

        public Customer AddData(Customer p_entry)
        {
            // List<Customer> custList = GetAllData();
            // custList.Add(p_entry);
            // _jsonString = JsonSerializer.Serialize(custList, new JsonSerializerOptions{WriteIndented = true});
            // File.WriteAllText(_filepath, _jsonString);
            // return custList[custList.Count-1];
            _context.Customers.Add(
                new Entities.Customer(){
                    CustomerId = p_entry.CustomerID,
                    Name = p_entry.Name,
                    Address = p_entry.Address,
                    Email = p_entry.Email,
                    Phone = p_entry.PhoneNumber
                }
            );

            _context.SaveChanges();
            return p_entry;
        }

        public List<Customer> GetAllData()
        {
            // try
            // {
            //     _jsonString = File.ReadAllText(_filepath);
            // }
            // catch (System.Exception)
            // {
            //     throw new FileNotFoundException();
            // }

            // return JsonSerializer.Deserialize<List<Customer>>(_jsonString);
            return _context.Customers.Select(
                cust => 
                    new Customer(){
                        CustomerID = cust.CustomerId,
                        Name = cust.Name,
                        Address = cust.Address,
                        Email = cust.Email,
                        PhoneNumber = (long)cust.Phone,
                        Orders = cust.Orders.Select(
                            ord =>
                                new Orders(){
                                    OrderID = ord.OrderId,
                                    CustomerID = ord.CustomerId,
                                    StoreFrontID = ord.StoreFrontId,
                                    Price = (double)ord.TotalPrice,
                                    OrderItems = ord.LineItems.Select(
                                        item =>
                                            new LineItems(){
                                                Product = item.Product.ToStoreModel(),
                                                Quantity = (int)item.Quantity,
                                                LineItemId = item.LineItemId,
                                                StoreFrontID = item.StoreFrontId,
                                                OrderID = item.OrderId,
                                                ProductID = (int)item.ProductId
                                            }
                                    ).ToList(),
                                    Location = ord.Location
                                }
                        ).ToList()
                    }
            ).ToList();
        }

        public List<Customer> NameSearch(string p_name){
            // List<Customer> custList = GetAllData();
            // List<Customer> retCust = new List<Customer>();
            // foreach(Customer c in custList){
            //     if (c.Name == p_name){
            //         retCust.Add(c);
            //     }
            // }
            // return retCust;

            return GetAllData().Where(c => c.Name == p_name).ToList();
        }
    }
}