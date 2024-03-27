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
    static User user = new User("admin", "password");
    static ProductCatalog productCatalog = new ProductCatalog();
    static Cart cart = new Cart();

    static void Main(string[] args)
    {
        bool exitProgram = false;

        while (!exitProgram)
        {
            Console.Clear();
            DisplayMenu();

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    user.AddUser();
                    break;
                case "2":
                    if (user.Login())
                    {
                        HandleUserActions();
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

    static void DisplayMenu()
    {
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Sign in");
        Console.WriteLine("2. Log in");
        Console.WriteLine("3. Exit");
        Console.WriteLine("Choose an option:");
    }

    static void HandleUserActions()
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
                    AddProduct();
                    break;
                case "2":
                    SearchProduct();
                    break;
                case "3":
                    GoToCart();
                    break;
                case "4":
                    Console.WriteLine("Logged out successfully!");
                    returnToMenu = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose a valid option.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void AddProduct()
    {
        Product product = new Product();
        Console.WriteLine("Enter product details:");

        bool validId = false;
        while (!validId)
        {
            Console.Write("Id: ");
            string idInput = Console.ReadLine();
            if (int.TryParse(idInput, out int id) && !Product.ProductExists(id))
            {
                product.Id = id;
                validId = true;
            }
            else
            {
                Console.WriteLine("Product with the same Id already exists or invalid input. Please choose a different Id.");
            }
        }

        Console.Write("Name: ");
        product.Name = Console.ReadLine();

        bool validPrice = false;
        while (!validPrice)
        {
            Console.Write("Price: ");
            string priceInput = Console.ReadLine();
            if (decimal.TryParse(priceInput, out decimal price))
            {
                product.Price = price;
                validPrice = true;
            }
            else
            {
                Console.WriteLine("Invalid input for price. Please enter a number.");
            }
        }

        Console.Write("Color: ");
        product.Color = Console.ReadLine();

        Console.Write("Brand: ");
        product.Brand = Console.ReadLine();

        productCatalog.AddProduct(product);
    }

    static void SearchProduct()
    {
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

                DisplayProducts(productsByBrand);
                break;
            case "2":
                Console.WriteLine("Enter color:");
                string color = Console.ReadLine();
                List<Product> productsByColor = productCatalog.SearchByColor(color);

                DisplayProducts(productsByColor);
                break;
            default:
                Console.WriteLine("Invalid option. Please choose a valid option.");
                break;
        }
    }

    static void DisplayProducts(List<Product> products)
    {
        foreach (Product p in products)
        {
            Console.WriteLine($"{p.Name} - {p.Price:C}");
        }
    }

    static void GoToCart()
    {
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
                    AddToCart();
                    break;
                case "2":
                    cart.DisplayCart();
                    break;
                case "3":
                    RemoveFromCart();
                    break;
                case "":
                    addToCart = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose a valid option.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void AddToCart()
    {
        Console.WriteLine("Enter the Id of the product to add to the cart:");
        string idInput = Console.ReadLine();
        if (int.TryParse(idInput, out int id))
        {
            cart.AddToCart(id);
        }
        else
        {
            Console.WriteLine("Invalid input for Id. Please enter a valid integer.");
        }
    }

    static void RemoveFromCart()
    {
        Console.WriteLine("Enter the Id of the product to remove from the cart:");
        string removeIdInput = Console.ReadLine();
        if (int.TryParse(removeIdInput, out int removeId))
        {
            cart.RemoveFromCart(removeId);
        }
        else
        {
            Console.WriteLine("Invalid input for Id. Please enter a valid integer.");
        }
    }
}

