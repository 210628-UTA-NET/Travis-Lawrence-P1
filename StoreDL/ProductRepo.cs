using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDL
{
    public class ProductRepo : IProductRepo
    {
        private StoreDBContext _context;
        public ProductRepo(StoreDBContext p_context)
        {
            _context = p_context;
        }

        public Product AddProduct(Product p_prod)
        {
            _context.Products.Add(p_prod);
            _context.SaveChanges();
            return p_prod;
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.Select(prod => prod).ToList();
        }

        public Product GetById(int p_id)
        {
            return _context.Products.Find(p_id);
        }

        public Product Update(Product p_prod)
        {
            _context.Products.Update(p_prod);
            _context.SaveChanges();
            return p_prod;
        }
    }
}
