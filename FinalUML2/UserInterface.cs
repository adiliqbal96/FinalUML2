using System;

namespace FinalUML2
{
    internal class UserInterface
    {
        private readonly PizzaMenu menu;
        private readonly CustomerCatalog customerCatalog;

        public UserInterface(PizzaMenu menu, CustomerCatalog customerCatalog)
        {
            this.menu = menu;
            this.customerCatalog = customerCatalog;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear(); // Clear the console screen

                Console.WriteLine("Welcome to Big Mamma Pizzeria!");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("1. Add Pizza");
                Console.WriteLine("2. View Pizzas");
                Console.WriteLine("3. Delete Pizza");
                Console.WriteLine("4. Update Pizza");
                Console.WriteLine("5. Search Pizza");
                Console.WriteLine("6. Add Customer");
                Console.WriteLine("7. View Customers");
                Console.WriteLine("8. Delete Customer");
                Console.WriteLine("9. Update Customer");
                Console.WriteLine("10. Search Customer");
                Console.WriteLine("11. Exit");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Enter the number of your choice:");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddPizza();
                        break;
                    case "2":
                        ViewPizzas();
                        break;
                    case "3":
                        DeletePizza();
                        break;
                    case "4":
                        UpdatePizza();
                        break;
                    case "5":
                        SearchPizza();
                        break;
                    case "6":
                        AddCustomer();
                        break;
                    case "7":
                        ViewCustomers();
                        break;
                    case "8":
                        DeleteCustomer();
                        break;
                    case "9":
                        UpdateCustomer();
                        break;
                    case "10":
                        SearchCustomer();
                        break;
                    case "11":
                        Console.WriteLine("Thank you for visiting Big Mamma Pizzeria. Goodbye!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 11.");
                        break;
                }
            }
        }

        private void AddPizza()
        {
            Console.Clear(); // Clear the console screen
            Console.WriteLine("Add a new pizza:");
            Console.WriteLine("----------------");

            Console.WriteLine("Enter pizza name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter pizza price:");
            decimal price;
            while (!decimal.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Invalid input. Please enter a valid price:");
            }

            menu.AddPizza(new Pizza(menu.GetPizzas().Count + 1, name, price));
            Console.WriteLine("Pizza added successfully. Press any key to continue...");
            Console.ReadKey();
        }

        private void ViewPizzas()
        {
            Console.Clear(); // Clear the console screen
            Console.WriteLine("List of Pizzas:");
            Console.WriteLine("---------------");

            menu.PrintMenu();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void DeletePizza()
        {
            Console.Clear();
            Console.WriteLine("Delete a pizza:");
            Console.WriteLine("---------------");

            Console.WriteLine("List of Pizzas:");
            Console.WriteLine("---------------");
            foreach (var pizza in menu.GetPizzas())
            {
                Console.WriteLine($"ID: {pizza.PizzaId}, Name: {pizza.Name}, Price: {pizza.Price}");
            }

            Console.WriteLine("Enter the ID of the pizza you want to delete:");
            int pizzaId;
            while (!int.TryParse(Console.ReadLine(), out pizzaId) || pizzaId <= 0 || pizzaId > menu.GetPizzas().Count)
            {
                Console.WriteLine("Invalid input. Please enter a valid pizza ID:");
            }

            menu.DeletePizza(pizzaId);

            // Reassign IDs to remaining pizzas
            int newId = 1;
            foreach (var pizza in menu.GetPizzas())
            {
                pizza.PizzaId = newId++;
            }

            Console.WriteLine($"Pizza with ID {pizzaId} deleted successfully.");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void UpdatePizza()
        {
            Console.Clear();
            Console.WriteLine("Update a pizza:");
            Console.WriteLine("---------------");

            Console.WriteLine("List of Pizzas:");
            Console.WriteLine("---------------");
            foreach (var pizza in menu.GetPizzas())
            {
                Console.WriteLine($"ID: {pizza.PizzaId}, Name: {pizza.Name}, Price: {pizza.Price}");
            }

            Console.WriteLine("Enter the ID of the pizza you want to update:");
            int pizzaId;
            while (!int.TryParse(Console.ReadLine(), out pizzaId) || pizzaId <= 0 || pizzaId > menu.GetPizzas().Count)
            {
                Console.WriteLine("Invalid input. Please enter a valid pizza ID:");
            }

            Console.WriteLine("Enter new name for the pizza:");
            string newName = Console.ReadLine();

            Console.WriteLine("Enter new price for the pizza:");
            decimal newPrice;
            while (!decimal.TryParse(Console.ReadLine(), out newPrice) || newPrice <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid price:");
            }

            menu.UpdatePizza(pizzaId, newName, newPrice);
            Console.WriteLine($"Pizza with ID {pizzaId} updated successfully.");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void SearchPizza()
        {
            Console.Clear();
            Console.WriteLine("Search for a pizza:");
            Console.WriteLine("-------------------");

            Console.WriteLine("Enter the name of the pizza you want to search:");
            string pizzaName = Console.ReadLine();

            Pizza result = menu.SearchPizza(pizzaName);
            if (result != null)
            {
                Console.WriteLine("Pizza found:");
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine($"Pizza with name '{pizzaName}' not found.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void AddCustomer()
        {
            Console.Clear(); // Clear the console screen
            Console.WriteLine("Add a new customer:");
            Console.WriteLine("--------------------");

            Console.WriteLine("Enter customer name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter customer address:");
            string address = Console.ReadLine();

            customerCatalog.AddCustomer(new Customer(customerCatalog.GetCustomers().Count + 1, name, address));
            Console.WriteLine("Customer added successfully. Press any key to continue...");
            Console.ReadKey();
        }

        private void ViewCustomers()
        {
            Console.Clear(); // Clear the console screen
            Console.WriteLine("List of Customers:");
            Console.WriteLine("------------------");

            customerCatalog.PrintCustomers();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void DeleteCustomer()
        {
            Console.Clear();
            Console.WriteLine("Delete a customer:");
            Console.WriteLine("-------------------");

            Console.WriteLine("List of Customers:");
            Console.WriteLine("------------------");
            foreach (var customer in customerCatalog.GetCustomers())
            {
                Console.WriteLine($"ID: {customer.CustomerId}, Name: {customer.Name}, Address: {customer.Address}");
            }

            Console.WriteLine("Enter the ID of the customer you want to delete:");
            int customerId;
            while (!int.TryParse(Console.ReadLine(), out customerId) || customerId <= 0 || customerId > customerCatalog.GetCustomers().Count)
            {
                Console.WriteLine("Invalid input. Please enter a valid customer ID:");
            }

            customerCatalog.DeleteCustomer(customerId);

            // Reassign IDs to remaining customers
            int newId = 1;
            foreach (var customer in customerCatalog.GetCustomers())
            {
                customer.CustomerId = newId++;
            }

            Console.WriteLine($"Customer with ID {customerId} deleted successfully.");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void UpdateCustomer()
        {
            Console.Clear();
            Console.WriteLine("Update a customer:");
            Console.WriteLine("-------------------");

            Console.WriteLine("List of Customers:");
            Console.WriteLine("------------------");
            foreach (var customer in customerCatalog.GetCustomers())
            {
                Console.WriteLine($"ID: {customer.CustomerId}, Name: {customer.Name}, Address: {customer.Address}");
            }

            Console.WriteLine("Enter the ID of the customer you want to update:");
            int customerId;
            while (!int.TryParse(Console.ReadLine(), out customerId) || customerId <= 0 || customerId > customerCatalog.GetCustomers().Count)
            {
                Console.WriteLine("Invalid input. Please enter a valid customer ID:");
            }

            Console.WriteLine("Enter new name for the customer:");
            string newName = Console.ReadLine();

            Console.WriteLine("Enter new address for the customer:");
            string newAddress = Console.ReadLine();

            customerCatalog.UpdateCustomer(customerId, newName, newAddress);
            Console.WriteLine($"Customer with ID {customerId} updated successfully.");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void SearchCustomer()
        {
            Console.Clear();
            Console.WriteLine("Search for a customer:");
            Console.WriteLine("-----------------------");

            Console.WriteLine("Enter the name of the customer you want to search:");
            string customerName = Console.ReadLine();

            Customer result = customerCatalog.SearchCustomer(customerName);
            if (result != null)
            {
                Console.WriteLine("Customer found:");
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine($"Customer with name '{customerName}' not found.");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

    }
}
