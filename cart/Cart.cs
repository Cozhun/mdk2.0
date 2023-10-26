using mdk2._0.product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

namespace mdk2._0.Новая_папка
{
    public class Cart
    {
        private List<Product> cartItems = new List<Product>();
        private ProductCatalog productCatalog = new ProductCatalog();

        public void AddToCart(Product product)
        {
            cartItems.Add(product);
        }

        public void AddToCart(int id)
        {
            List<Product> productsById = productCatalog.SearchById(id);

            cartItems.AddRange(productsById);
        }

        public void RemoveFromCart(int id)
        {
            List<Product> productsToRemove = productCatalog.SearchById(id);

            foreach (Product product in productsToRemove)
            {
                cartItems.Remove(product);
            }
        }

        public void DisplayCart()
        {
            Console.WriteLine("Items in the Cart:");
            foreach (Product product in cartItems)
            {
                Console.WriteLine($"Name: {product.Name}");
                Console.WriteLine($"Price: {product.Price:C}");
                Console.WriteLine($"Color: {product.Color}");
                Console.WriteLine($"Brand: {product.Brand}");
                Console.WriteLine(); // Empty line for separation
            }
        }
    }
}

