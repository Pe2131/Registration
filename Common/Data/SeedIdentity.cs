using DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Data
{
    public class SeedIdentity
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public SeedIdentity(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task init()
        {
            await SeedRoles();
            await SeedUsers();
        }
        private async Task SeedRoles()
        {
            await _roleManager.CreateAsync(new IdentityRole("Admin"));
            await _roleManager.CreateAsync(new IdentityRole("User"));
            await _roleManager.CreateAsync(new IdentityRole("Suport"));
        }
        private async Task SeedUsers()
        {
            var user = await _userManager.FindByNameAsync("admin@admin.com");
            if (user == null)
            {
                var Admin = new ApplicationUser
                {
                    Email = "admin@admin.com",
                    UserName = "admin@admin.com",
                    IsActive = true
                };
                await _userManager.CreateAsync(Admin, "Admin@123456");
                await _userManager.AddToRoleAsync(Admin, "Admin");
            }
            var support = await _userManager.FindByNameAsync("admin@support.com");
            if (support == null)
            {
                var Support = new ApplicationUser
                {
                    Email = "admin@support.com",
                    UserName = "admin@support.com",
                    IsActive = true
                };
                await _userManager.CreateAsync(Support, "Admin@123456");
                await _userManager.AddToRoleAsync(Support, "Suport");
            }
        }
    }
}
