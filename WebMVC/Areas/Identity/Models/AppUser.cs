using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Areas.Identity.Models
{
    public class AppUser : IdentityUser
    {
        [Display(Name ="Full Name")]
        [PersonalData]
        public string FullName { get; set; }
    }
}
