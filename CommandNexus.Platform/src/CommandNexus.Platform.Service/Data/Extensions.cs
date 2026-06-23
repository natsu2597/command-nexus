using Microsoft.EntityFrameworkCore;

namespace CommandNexus.Platform.Service.Data
{
    public static class Extensions
    {
        public static IServiceCollection AddDb(this IServiceCollection services)
        {
            services.AddDbContext<AppDBContext>(opt =>
                                opt.UseInMemoryDatabase("InMem"));
            services.AddScoped(typeof(IRepository<>),
                                       typeof(CommandNexusRepo<>));

            return services;

        }
    }
}
