using CRM.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace CRM.Api.Seeding
{
    public static class IdentitySeeder
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            var roles = new[] { "Admin", "Manager", "User" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new ApplicationRole
                    {
                        Name = role,
                        NormalizedName = role.ToUpper()
                    });
                }
            }

            var users = new[]
            {
                new { Email = "admin@crm.pl", FirstName = "John", LastName = "Kowalski", Password = "Admin123!", Role = "Admin" },
                new { Email = "manager@crm.pl", FirstName = "Jack", LastName = "Sparrow", Password = "Manager123!", Role = "Manager" },
                new { Email = "user@crm.pl", FirstName = "James", LastName = "Hurley", Password = "User123!", Role = "User" }
            };

            foreach (var u in users)
            {
                var existingUser = await userManager.FindByEmailAsync(u.Email);

                if (existingUser == null)
                {
                    var user = new ApplicationUser
                    {
                        UserName = u.Email,
                        Email = u.Email,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        EmailConfirmed = true
                    };

                    var result = await userManager.CreateAsync(user, u.Password);

                    await userManager.AddToRoleAsync(user, u.Role);
                    
                }
            }
        }
    }
}
