using CommandNexus.Platform.Service.Models;

namespace CommandNexus.Platform.Service.Data
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDBContext _context;

        public PlatformRepo(AppDBContext context)
        {
            _context = context;
        }

        public void CreatePlatform(PlatformModel platform)
        {
            if(platform == null)
                throw new ArgumentNullException(nameof(platform));

            _context.Platforms.Add(platform);
        }

        public IEnumerable<PlatformModel> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public PlatformModel? GetPlatformById(Guid id)
        {
            return _context.Platforms.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
