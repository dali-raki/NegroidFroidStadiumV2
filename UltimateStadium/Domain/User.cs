namespace BlazorApp1.Domain
{
    public class User
    {
        public string UserId { get; set; }
        public string Gmail { get; set; }
        public UserRole Role { get; set; }

   
        public List<Claim> Claims { get; set; } = new List<Claim>(); 
    }
}