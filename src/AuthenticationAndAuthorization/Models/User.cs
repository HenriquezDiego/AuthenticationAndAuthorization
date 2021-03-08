namespace AuthenticationAndAuthorization.Models
{
    public class User
    {
        public int Id { get; init; }
        public string Username { get; init; }
        public string Password { get; set; }
        public string Role { get; init; }
    }
}
