using goglobe_API.Auth.Model;
using goglobe_API.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace goglobe_API.Data
{
    public class DatabaseSeeder
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DatabaseSeeder(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            foreach(var role in UserRoles.All)
            {
                var roleExist = await _roleManager.RoleExistsAsync(role);
                if(!roleExist)
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
