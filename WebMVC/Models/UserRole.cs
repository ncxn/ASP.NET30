﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Models
{
    public class UserRole: IdentityUserRole<int>
    {
        public string Role_name { get; set; }

        public string User_name { get; set; }
    }
}