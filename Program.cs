using mdk2._0.product;
using mdk2._0.User;
using mdk2._0.Новая_папка;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MainClass
{
    public static void Main(string[] args)
    {
        User user = new User("admin", "password");
        ProductCatalog productCatalog = new ProductCatalog();
        Cart cart = new Cart();

        bool exitProgram = false;

        while (!exitProgram)
        {
            Console.Clear();
            {
                user.AddAdmin();
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Sign in");
                Console.WriteLine("2. Log in");
                Console.WriteLine("3. Exit");
                Console.WriteLine("Choose an option:");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        user.AddUser();
                        break;
                    case "2":
                        bool loggedIn = user.Login();
                        if (loggedIn)
                        {
                            bool returnToMenu = true;

                            while (returnToMenu)
                            {
                                Console.WriteLine("Menu:");
                                Console.WriteLine("1. Add product");
                                Console.WriteLine("2. Search paint");
                                Console.WriteLine("3. Go to cart");
                                Console.WriteLine("4. Log out");
                                Console.WriteLine("Choose an option:");

                                string userOption = Console.ReadLine();

                                switch (userOption)
                                {
                                    case "1":
                                        Product product = new Product();
                                        Console.WriteLine("Enter product details:");

                                        bool validId = false;
                                        while (!validId)
                                        {
                                            Console.Write("Id: ");
                                            string idInput = Console.ReadLine();
                                            try
                                            {
                                                int id = Convert.ToInt32(idInput);

                                                if (!Product.ProductExists(id))
                                                {
                                                    product.Id = id;
                                                    validId = true;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Product with the same Id already exists. Please choose a different Id.");
                                                }
                                            }
                                            catch (FormatException)
                                            {
                                                Console.WriteLine("Invalid input for Id. Please enter a valid integer.");
                                            }
                                        }

                                        Console.Write("Name: ");
                                        product.Name = Console.ReadLine();

                                        bool validPrice = false;
                                        while (!validPrice)
                                        {
                                            Console.Write("Price: ");
                                            string priceInput = Console.ReadLine();
                                            try
                                            {
                                                product.Price = Convert.ToDecimal(priceInput);
                                                validPrice = true;
                                            }
                                            catch (FormatException)
                                            {
                                                Console.WriteLine("Invalid input for price. Please enter a number.");
                                            }
                                        }

                                        Console.Write("Color: ");
                                        product.Color = Console.ReadLine();

                                        Console.Write("Brand: ");
                                        product.Brand = Console.ReadLine();

                                        productCatalog.AddProduct(product);
                                        break;


                                    case "2":
                                        Console.WriteLine("Search paint:");
                                        Console.WriteLine("1. Search by brand");
                                        Console.WriteLine("2. Search by color");
                                        Console.WriteLine("Choose an option:");
                                        string searchOption = Console.ReadLine();

                                        switch (searchOption)
                                        {
                                            case "1":
                                                Console.WriteLine("Enter brand:");
                                                string brand = Console.ReadLine();
                                                List<Product> productsByBrand = productCatalog.SearchByBrand(brand);

                                                foreach (Product p in productsByBrand)
                                                {
                                                    Console.WriteLine($"{p.Name} - {p.Price:C}");
                                                }
                                                break;
                                            case "2":
                                                Console.WriteLine("Enter color:");
                                                string color = Console.ReadLine();
                                                List<Product> productsByColor = productCatalog.SearchByColor(color);

                                                foreach (Product p in productsByColor)
                                                {
                                                    Console.WriteLine($"{p.Name} - {p.Price:C}");
                                                }
                                                break;
                                            default:
                                                Console.WriteLine("Invalid option. Please choose a valid option.");
                                                break;
                                        }
                                        break;
                                    case "3":
                                        Console.WriteLine("Going to cart...");
                                        bool addToCart = true;

                                        while (addToCart)
                                        {
                                            Console.WriteLine("1. Add product to cart by Id");
                                            Console.WriteLine("2. Print cart");
                                            Console.WriteLine("3. Remove product from cart by Id");
                                            Console.WriteLine("Press Enter to go back to the previous menu.");

                                            string cartOption = Console.ReadLine();

                                            switch (cartOption)
                                            {
                                                case "1":
                                                    Console.WriteLine("Enter the Id of the product to add to the cart:");
                                                    string idInput = Console.ReadLine();
                                                    try
                                                    {
                                                        int id = Convert.ToInt32(idInput);
                                                        cart.AddToCart(id);
                                                    }
                                                    catch (FormatException)
                                                    {
                                                        Console.WriteLine("Invalid input for Id. Please enter a valid integer.");
                                                    }
                                                    break;
                                                case "2":
                                                    cart.DisplayCart();
                                                    break;
                                                case "3":
                                                    Console.WriteLine("Enter the Id of the product to remove from the cart:");
                                                    string removeIdInput = Console.ReadLine();
                                                    try
                                                    {
                                                        int removeId = Convert.ToInt32(removeIdInput);
                                                        cart.RemoveFromCart(removeId);
                                                    }
                                                    catch (FormatException)
                                                    {
                                                        Console.WriteLine("Invalid input for Id. Please enter a valid integer.");
                                                    }
                                                    break;
                                                case "":
                                                    addToCart = false; // Exit the inner loop
                                                    break;
                                                default:
                                                    Console.WriteLine("Invalid option. Please choose a valid option.");
                                                    break;
                                            }

                                            Console.WriteLine();
                                        }
                                        break;


                                    case "4":
                                        Console.WriteLine("Logged out successfully!");
                                        returnToMenu = false; // Exit the inner loop
                                        break;
                                    default:
                                        Console.WriteLine("Invalid option. Please choose a valid option.");
                                        break;
                                }

                                Console.WriteLine();
                            }
                        }
                        break;

                    case "3":
                        exitProgram = true;
                        Console.WriteLine("Exiting the program...");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose a valid option.");
                        break;

                }

                Console.WriteLine();
            }
        }
    }
}
