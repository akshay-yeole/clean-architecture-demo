using application.Validators;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace application
{
    public static class ServiceExtensions
    {
        public static void AddApplication(this IServiceCollection services) {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(conf => conf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviours<,>));
        }
    }
}
