using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalUML2
{
    internal class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public Customer(int customerId, string name, string address)
        {
            CustomerId = customerId;
            Name = name;
            Address = address;
        }

        public override string ToString()
        {
            return $"ID: {CustomerId}, Name: {Name}, Address: {Address}";
        }
    }
}
