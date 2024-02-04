using application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Context;
using Persistance.IdentityModels;
using Persistance.Seeds;
using Persistance.SharedServices;

namespace Persistance
{
    public static class ServiceExntensions
    {
        public static void AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("Default")));
            
            services.AddIdentityCore<ApplicationUser>()
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddTransient<IAccountService, AccountService>();

            //seed roles and users
            DefaultRoles.SeedRoleAsync(services.BuildServiceProvider()).Wait();
            DefaultUsers.SeedUsersAsync(services.BuildServiceProvider()).Wait();

        }
    }
}