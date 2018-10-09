using System.Collections.Generic;

namespace WebShop.Core.Entity
{
    public class Customer : User
    {
        public string Address { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        public List<Order> Orders { get; set; }
    }
}