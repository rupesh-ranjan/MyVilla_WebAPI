﻿using Microsoft.AspNetCore.Identity;

namespace MyVilla_VillaAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
