using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Linq;

namespace mdk2._0.product
{
    public class ProductCatalog
    {
        public void AddProduct(Product product)
        {
            Product.AddProductToList(product);
        }

        public List<Product> SearchByColor(string color)
        {
            List<Product> result = new List<Product>();
            foreach (Product product in Product.GetProducts())
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
            foreach (Product product in Product.GetProducts())
            {
                if (product.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(product);
                }
            }
            return result;
        }

        public List<Product> SearchById(int id)
        {
            List<Product> result = new List<Product>();
            foreach (Product product in Product.GetProducts())
            {
                if (product.Id == id)
                {
                    result.Add(product);
                }
            }
            return result;
        }

    }
}
