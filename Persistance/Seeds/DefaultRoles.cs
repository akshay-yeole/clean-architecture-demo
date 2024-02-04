using application.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Persistance.IdentityModels;

namespace Persistance.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedRoleAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            var role = new ApplicationRole();
            role.Name = Roles.SuperAdmin.ToString();
            role.NormalizedName = Roles.SuperAdmin.ToString().ToUpper();
            await roleManager.CreateAsync(role);

            var roleAdmin = new ApplicationRole();
            roleAdmin.Name = Roles.admin.ToString();
            roleAdmin.NormalizedName = Roles.admin.ToString().ToUpper();
            await roleManager.CreateAsync(roleAdmin);

            var basic = new ApplicationRole();
            basic.Name = Roles.Basic.ToString();
            basic.NormalizedName = Roles.Basic.ToString().ToUpper();
            await roleManager.CreateAsync(basic);
        }
    }
}
