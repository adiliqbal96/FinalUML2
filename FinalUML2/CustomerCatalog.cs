using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalUML2
{
    internal class CustomerCatalog
    {
        private List<Customer> customers;

        public CustomerCatalog()
        {
            customers = new List<Customer>
            {
                new Customer(1, "John Doe", "Hovedgaden 410"),
                new Customer(2, "Jane Smith", "Restrupvej 80"),
                new Customer(3, "Alice Johnson", "Egyptensvej 34")
            };
        }

        public List<Customer> GetCustomers()
        {
            return customers;
        }

        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        public void DeleteCustomer(int customerId)
        {
            Customer customerToRemove = customers.Find(c => c.CustomerId == customerId);
            if (customerToRemove != null)
            {
                customers.Remove(customerToRemove);
            }
        }

        public void UpdateCustomer(int customerId, string newName, string newAddress)
        {
            Customer customerToUpdate = customers.Find(c => c.CustomerId == customerId);
            if (customerToUpdate != null)
            {
                customerToUpdate.Name = newName;
                customerToUpdate.Address = newAddress;
            }
        }

        public Customer SearchCustomer(string criteria)
        {
            return customers.Find(c => c.Name.ToLower() == criteria.ToLower());
        }

        public void PrintCustomers()
        {
            Console.WriteLine("Customers:");
            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }
        }
    }
}