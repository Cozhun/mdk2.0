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
    public class Product
    {
        private static List<Product> productList = new List<Product>();
        private int id;
        private string name;
        private decimal price;
        private string color;
        private string brand;

        public int Id
        {
            get { return id; }
            set
            {
                try
                {
                    id = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error setting Id: " + e.Message);
                }
            }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public decimal Price
        {
            get { return price; }
            set
            {
                try
                {
                    price = value;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error setting Price: " + e.Message);
                }
            }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        public static void AddProductToList(Product product)
        {
            productList.Add(product);
        }

        public static List<Product> GetProducts()
        {
            return productList;
        }

        public static bool ProductExists(int id)
        {
            return productList.Any(product => product.Id == id);
        }
    }
}
