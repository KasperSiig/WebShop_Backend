using System.Collections.Generic;

namespace WebShop.Core.Entity
{
    public class Customer
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
        public List<Order> Orders { get; set; }
        public User User { get; set; }
    }
}