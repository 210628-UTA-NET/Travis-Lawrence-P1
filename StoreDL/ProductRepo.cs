using System.Collections.Generic;
using StoreModels;
using System.Linq;

namespace StoreDL
{
    public class ProductRepo : IProductRepo
    {
        private Entities.DemoDbContext _context;

        public ProductRepo(Entities.DemoDbContext p_context){
            _context = p_context;
        }

        public Products AddData(Products p_entry)
        {
            throw new System.NotImplementedException();
        }

        public List<Products> GetAllData()
        {
            return _context.Products.Select(
                prod =>
                    new Products(){
                        ProductID = prod.ProductId,
                        Name = prod.Name,
                        Price = (double)prod.Price,
                        Desc = prod.Description,
                        Category = prod.Category
                    }
            ).ToList();
        }
    }
}