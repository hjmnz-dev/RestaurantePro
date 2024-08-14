using Microsoft.Extensions.DependencyInjection;


using RestaurantePro.Cliente.Application.Interfaces;
using RestaurantePro.Cliente.Application.Services;
using RestaurantePro.Cliente.Domain.Interface;
using RestaurantePro.Cliente.Persistance.Repositories;


namespace RestaurantePro.Cliente.IOC.Dependencies
{
    public static class ClienteDependencies
    {
        public static void AddClienteDependency(this IServiceCollection service) 
        { 
          service.AddScoped<IClienteRepository,ClienteRepository>();  
          service.AddTransient<IClienteService,ClienteService>();  
        }
    }
}
