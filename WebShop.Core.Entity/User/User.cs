namespace WebShop.Core.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }

        public Employee Employee { get; set; }
        public Customer Customer { get; set; }
    }
}