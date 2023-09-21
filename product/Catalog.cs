using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mdk2._0.product
{
    public class ProductCatalog
    {
        private List<Product> products = new List<Product>();

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public List<Product> SearchByColor(string color)
        {
            List<Product> result = new List<Product>();
            foreach (Product product in products)
            {
                if (product.Color.Equals(color, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(product);
                }
            }
            return result;
        }

        public List<Product> SearchByBrand(string brand)
        {
            List<Product> result = new List<Product>();
            foreach (Product product in products)
            {
                if (product.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(product);
                }
            }
            return result;
        }
    }
}