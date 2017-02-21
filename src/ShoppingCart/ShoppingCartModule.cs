using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public class Product
    {
        public int ProductCatalogId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; } 
    }
    public class ShoppingCartStore : IShoppingCartStore
    {
        public ShoppingCart Get(int userId)
        {
            return new ShoppingCart
            {
                UserId = userId,
                Items = new List<Product>
                {
                    new Product {
                        ProductCatalogId = 1,
                        ProductName = "Basic t-shit",
                        Description = "a quiet t-shirt"
                    }
                }
            };
        }
    }
    public class ShoppingCart
    {
        public int UserId { get; set; }
        public List<Product> Items { get; set; }
//"description": "a quiet t-shirt",
//"price": {
//"currency": "eur",
//"amount": 40
//}
//},
    }
    public interface IShoppingCartStore
    {
        ShoppingCart Get(int userId);
    }
    public class ShoppingCartModule: NancyModule
    {
        public ShoppingCartModule(IShoppingCartStore shoppingCartStore): base("/shoppingcart")
        {
            Get("/{userid:int}", parameters =>
            {
                var userId = (int)parameters.userid;
                return shoppingCartStore.Get(userId);
            });
        }
    }
}
