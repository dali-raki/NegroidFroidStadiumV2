namespace UltimateStadium.Components.Models.UsersModels
{
    public class UserModel
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int role { get; set; }
        public UserModel(string id, string email, string password, int role)
        {
            this.Id = id;
            this.Email = email;
            this.Password = password;
            this.role = role;
        }
    }
}
