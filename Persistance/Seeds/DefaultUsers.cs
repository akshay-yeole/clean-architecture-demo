using application.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Persistance.IdentityModels;

namespace Persistance.Seeds
{
    public static class DefaultUsers
    {
        public static async Task SeedUsersAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var user = new ApplicationUser();
            user.UserName = "user";
            user.FirstName = "user";
            user.LastName = "user";
            user.Email = "user@gmail.com";
            user.EmailConfirmed = true;
            user.PhoneNumberConfirmed = true;

            if (userManager.Users.All(x => x.Id != user.Id))
            {
                var result = await userManager.FindByEmailAsync(user.Email);

                if (result == null)
                {
                    await userManager.CreateAsync(user, "Test@123");
                    await userManager.AddToRoleAsync(user, Roles.SuperAdmin.ToString());
                    await userManager.AddToRoleAsync(user, Roles.admin.ToString());
                    await userManager.AddToRoleAsync(user, Roles.Basic.ToString());

                }
            }
        }
    }
}
