using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreModels;

namespace StoreDL
{
    public interface ILineItemRepo
    {
        List<LineItem> GetAllLineItems();
        LineItem GetById(int p_id);
        LineItem AddLineItem(LineItem p_line);
        LineItem Update(LineItem p_line);
    }
}
