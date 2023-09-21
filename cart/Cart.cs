using mdk2._0.product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void AddToCart(string color, string brand)
        {
            List<Product> productsByColor = productCatalog.SearchByColor(color);
            List<Product> productsByBrand = productCatalog.SearchByBrand(brand);

            // Intersection of products by color and brand
            List<Product> productsToAdd = productsByColor.Intersect(productsByBrand).ToList();

            cartItems.AddRange(productsToAdd);
        }

        public void RemoveFromCart(Product product)
        {
            cartItems.Remove(product);
        }

        public void DisplayCart()
        {
            Console.WriteLine("Items in the Cart:");
            foreach (Product product in cartItems)
            {
                Console.WriteLine($"{product.Name} - {product.Price:C}");
            }
        }

        internal void AddToCart(string? productToAdd)
        {
            throw new NotImplementedException();
        }
    }
}