using System;
namespace CookingApp.Services
{
    public class Profile
    {
        public Profile()
        {
            Id = Guid.NewGuid().ToString();
            Name = "Guest User";
            Email = string.Empty;
            Password = string.Empty;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

    }
}
