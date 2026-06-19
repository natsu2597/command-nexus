using CommandNexus.Platform.Service.Models;

namespace CommandNexus.Platform.Service.Data
{
    public interface IPlatformRepo 
    {
        bool SaveChanges();

        IEnumerable<PlatformModel> GetAllPlatforms();
        PlatformModel? GetPlatformById(Guid id);
        void CreatePlatform(PlatformModel platform);
    }
}
