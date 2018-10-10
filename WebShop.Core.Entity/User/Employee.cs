namespace WebShop.Core.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        public int AccessLvl { get; set; }
        public User User { get; set; }
    }
}