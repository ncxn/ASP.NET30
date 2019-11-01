using Microsoft.AspNetCore.Identity;

namespace WebMVC.Models
{
    public class Roles: IdentityRole
    {
        public string Role_name { get; set; }

        public string Role_description { get; set; }
    }
}