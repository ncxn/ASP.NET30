﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Areas.Identity.Models
{
    public class AppRole: IdentityRole
    {
        public string Description { get; set; }
    }
}
