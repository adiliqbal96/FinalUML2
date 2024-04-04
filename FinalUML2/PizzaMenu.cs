using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalUML2
{
    internal class PizzaMenu
    {
        private List<Pizza> pizzas;

        public PizzaMenu()
        {
            pizzas = new List<Pizza>
            {
                new Pizza(1, "Margherita", 89),
                new Pizza(2, "Pepperoni", 99),
                new Pizza(3, "Hawaiian", 109)
            };
        }

        public List<Pizza> GetPizzas()
        {
            return pizzas;
        }

        public void AddPizza(Pizza pizza)
        {
            pizzas.Add(pizza);
        }

        public void DeletePizza(int pizzaId)
        {
            Pizza pizzaToRemove = pizzas.FirstOrDefault(p => p.PizzaId == pizzaId);
            if (pizzaToRemove != null)
            {
                pizzas.Remove(pizzaToRemove);
            }
        }

        public void UpdatePizza(int pizzaId, string newName, decimal newPrice)
        {
            Pizza pizzaToUpdate = pizzas.FirstOrDefault(p => p.PizzaId == pizzaId);
            if (pizzaToUpdate != null)
            {
                pizzaToUpdate.Name = newName;
                pizzaToUpdate.Price = newPrice;
            }
        }

        public Pizza SearchPizza(string criteria)
        {
            return pizzas.FirstOrDefault(p => p.Name.ToLower() == criteria.ToLower());
        }

        public void PrintMenu()
        {
            Console.WriteLine("Menu:");
            foreach (var pizza in pizzas)
            {
                Console.WriteLine(pizza);
            }
        }
    }

}
