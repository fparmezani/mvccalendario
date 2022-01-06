using Microsoft.Extensions.DependencyInjection;
using MvcCalendario.Business.Interfaces;
using MvcCalendario.Business.Notifications;
using MvcCalendario.Business.Services;
using MvcCalendario.Data.Context;
using MvcCalendario.Data.Repository;

namespace MvcCalendario.App.Configurations
{
    public static class DependencyInjectionConfig
    {

        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MvcContext>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();


            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IClienteService, ClienteService>();


            return services;
        }

    }
}
