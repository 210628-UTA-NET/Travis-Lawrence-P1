using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDL
{
    public class LineItemRepo : ILineItemRepo
    {
        private StoreDBContext _context;
        public LineItemRepo(StoreDBContext p_context)
        {
            _context = p_context;
        }

        public LineItem AddLineItem(LineItem p_line)
        {
            _context.LineItems.Add(p_line);
            _context.SaveChanges();
            return p_line;
        }

        public List<LineItem> GetAllLineItems()
        {
            return _context.LineItems.Select(line => line).ToList();
        }

        public LineItem GetById(int p_id)
        {
            return _context.LineItems.Find(p_id);
        }

        public LineItem Update(LineItem p_line)
        {
            _context.LineItems.Update(p_line);
            _context.SaveChanges();
            return p_line;
        }
    }
}
