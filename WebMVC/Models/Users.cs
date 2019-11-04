using Microsoft.AspNetCore.Identity;
using System;

namespace WebMVC.Models
{
    public class Users : IdentityUser
    {
        public int User_id { get; set; }
        public string User_name { get; set; }
        public string User_first_name { get; set; }
        public string User_last_name { get; set; }
        public string User_email { get; set; }
        public string User_password { get; set; }
        public int User_status { get; set; }
        public DateTime User_created_at { get; set; }
        public DateTime User_updated_at { get; set; }
    }
}
