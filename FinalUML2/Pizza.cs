using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalUML2
{
    internal class Pizza
    {
        public int PizzaId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Pizza(int pizzaId, string name, decimal price)
        {
            PizzaId = pizzaId;
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"ID: {PizzaId}, Name: {Name}, Price: {Price} DKK";
        }
    }
}
