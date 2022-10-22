using GapUp.Data.Contracts;
using GapUp.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GapUp.Services.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();
    }
}
