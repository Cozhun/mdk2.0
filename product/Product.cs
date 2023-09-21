using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mdk2._0.product
{
    public class Product
    {
        private string name;
        private decimal price;
        private string color;
        private string brand;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public string Brand
        {
            get { return brand; }
            set
            {
                brand = value;
            }
        }
    }
}
