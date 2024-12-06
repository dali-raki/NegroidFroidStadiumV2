

namespace BlazorApp1.Domain
{
    
    public class Claim
    {
        public string Type { get; set; }
        public string Value { get; set; } 
    }


    public enum UserRole
    {
        Admin=3,
        Manager=2,
        Client=1
    }
}
