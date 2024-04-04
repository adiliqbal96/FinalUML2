using System;

namespace FinalUML2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PizzaMenu pizzaMenu = new PizzaMenu();
            CustomerCatalog customerCatalog = new CustomerCatalog(); // Instantiate CustomerCatalog

            UserInterface ui = new UserInterface(pizzaMenu, customerCatalog); // Pass both pizzaMenu and customerCatalog
            ui.Run();
        }
    }
}
