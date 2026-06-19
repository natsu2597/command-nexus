using Microsoft.EntityFrameworkCore;
using CommandNexus.Platform.Service.Models;

namespace CommandNexus.Platform.Service.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> opt) : base(opt)
        {
            
        }

        public DbSet<PlatformModel> Platforms { get; set; }
    }
}
