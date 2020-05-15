using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace DAL.Models
{
   public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
        public  bool IsActive { get; set; }
    }
}
