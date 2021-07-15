using StoreModels;
using System.Linq;

namespace StoreDL
{
    public static class StoreConvert{

        public static Entities.Product ToEntModel(Products p_prod){
            return new Entities.Product(){
                ProductId = p_prod.ProductID,
                Name = p_prod.Name,
                Price = (decimal?)p_prod.Price,
                Description = p_prod.Desc,
                Category = p_prod.Category
            };
        }

        public static Entities.LineItem ToEntModel(LineItems p_line){
            return new Entities.LineItem(){
                LineItemId = p_line.LineItemId,
                StoreFrontId = p_line.StoreFrontID,
                OrderId = p_line.OrderID,
                ProductId = p_line.Product.ProductID,
                Quantity = p_line.Quantity
            };
        }

        public static Entities.Order ToEntModel(Orders p_ord){
            return new Entities.Order(){
                OrderId = p_ord.OrderID,
                CustomerId = p_ord.CustomerID,
                StoreFrontId = p_ord.StoreFrontID,
                LineItems = p_ord.OrderItems.Select(
                    line =>
                        ToEntModel(line)
                ).ToList(),
                TotalPrice = (decimal?)p_ord.Price,
                Location = p_ord.Location
            };
        }

        public static Entities.StoreFront ToEntModel(StoreFront p_store){
            return new Entities.StoreFront(){
                StoreFrontId = p_store.StoreID,
                Name = p_store.Name,
                Address = p_store.Address,
                LineItems = p_store.Inventory.Select(
                    line =>
                        ToEntModel(line)
                ).ToList()
            };
        }

        // public static Orders ToStoreModel(Entities.Order p_ord){
        //     try
        //     {
        //     return new Orders(){
        //         OrderID = p_ord.OrderId,
        //         CustomerID = p_ord.CustomerId,
        //         StoreFrontID = p_ord.StoreFrontId,
        //         Price = (double)p_ord.TotalPrice,
        //         OrderItems = p_ord.LineItems.Select(
        //             item =>
        //                 ToStoreModel(item)
        //         ).ToList(),
        //         Location = p_ord.Location
        //     };
        //     }
        //     catch (System.NullReferenceException)
        //     {
        //         return new Orders("Big sad");
        //     }
        // }

        // public static LineItems ToStoreModel(Entities.LineItem p_line){
        //     return new LineItems(){
        //         Product = p_line.Product.ToStoreModel(),
        //         Quantity = (int)p_line.Quantity,
        //         LineItemId = p_line.LineItemId,
        //         StoreFrontID = p_line.StoreFrontId,
        //         OrderID = p_line.OrderId,
        //         ProductID = (int)p_line.ProductId
        //     };
        // }
    }
}