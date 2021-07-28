using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreModels;

namespace StoreDL
{
    public interface IProductRepo
    {
        List<Product> GetAllProducts();
        Product GetById(int p_id);
        Product AddProduct(Product p_prod);
        Product Update(Product p_prod);
    }
}
