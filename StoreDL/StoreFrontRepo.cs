using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using StoreModels;
using System.Linq;

namespace StoreDL
{
    public class StoreFrontRepo : IStoreFrontRepo
    {
        //private const string _filepath = "./../StoreDL/Databases/StoreFronts.json";
        //private string _jsonString;
        private Entities.DemoDbContext _context;

        public StoreFrontRepo(Entities.DemoDbContext p_context){
            _context = p_context;
        }

        public StoreFront AddData(StoreFront p_entry)
        {
            throw new System.NotImplementedException();
        }

        public List<StoreFront> GetAllData()
        {
            // try
            // {
            //     _jsonString = File.ReadAllText(_filepath);
            // }
            // catch (System.Exception)
            // {
            //     throw new FileNotFoundException();
            // }
            // return JsonSerializer.Deserialize<List<StoreFront>>(_jsonString);
            return _context.StoreFronts.Select(
                store =>
                    new StoreFront(){
                        StoreID = store.StoreFrontId,
                        Name = store.Name,
                        Address = store.Address,
                        Inventory = store.LineItems.Select(
                            line =>
                                new LineItems(){
                                    LineItemId = line.LineItemId,
                                    StoreFrontID = line.StoreFrontId,
                                    OrderID = line.OrderId,
                                    Product = line.Product.ToStoreModel(),
                                    Quantity = (int)line.Quantity
                                }
                        ).ToList(),
                        Orders = store.Orders.Select(
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

        public List<StoreFront> NameSearch(string p_name)
        {
            // List<StoreFront> storeFList = GetAllData();
            // List<StoreFront> retStoreF = new List<StoreFront>();
            // foreach(StoreFront s in storeFList){
            //     if(s.Name == p_name){
            //         retStoreF.Add(s);
            //     }
            // }
            // return retStoreF;
            return GetAllData().Where(s => s.Name == p_name).ToList();
        }

        public bool Update(StoreFront p_store){
            _context.Update(StoreConvert.ToEntModel(p_store));
            _context.SaveChanges();
            return true;
        }
    }
}