using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace CommandNexus.Common.Database
{
    public static class Extensions
    {
        public static IServiceCollection AddDb<TContext>(this IServiceCollection services) where TContext : DbContext
        {
            services.AddScoped<DbContext, TContext>();
            services.AddScoped(typeof(IRepository<>),
                                       typeof(CommandNexusRepo<>));

            return services;

        }
    }
}
