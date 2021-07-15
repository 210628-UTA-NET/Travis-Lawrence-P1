using System;
using System.Collections.Generic;
using StoreModels;
using System.Linq;

namespace StoreDL
{
    public class OrderRepo : IOrderRepo
    {
        private Entities.DemoDbContext _context;

        public OrderRepo(Entities.DemoDbContext p_context){
            _context = p_context;
        }

        public Orders AddData(Orders p_entry)
        {
            Entities.Order newEntry = StoreConvert.ToEntModel(p_entry);
            foreach (Entities.LineItem i in newEntry.LineItems)
            {
                i.Order = newEntry;
            }
            _context.Orders.Add(newEntry);
            _context.SaveChanges();
            return p_entry;
        }

        public List<Orders> GetAllData()
        {
            throw new NotImplementedException();
        }
    }
}