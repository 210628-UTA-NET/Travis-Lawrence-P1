using System.Collections.Generic;
using StoreModels;
using System.Linq;

namespace StoreDL
{
    public class LineItemRepo : ILineItemRepo
    {
        private Entities.DemoDbContext _context;

        public LineItemRepo(Entities.DemoDbContext p_context){
            _context = p_context;
        }

        public LineItems AddData(LineItems p_entry)
        {
            throw new System.NotImplementedException();
        }

        public List<LineItems> GetAllData()
        {
            return _context.LineItems.Select(
                line =>
                    new LineItems(){
                        Product = line.Product.ToStoreModel(),
                        Quantity = (int)line.Quantity
                    }
            ).ToList();
        }
    }
}