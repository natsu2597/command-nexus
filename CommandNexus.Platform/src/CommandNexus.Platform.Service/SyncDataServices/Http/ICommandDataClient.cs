using CommandNexus.Platform.Service.Dtos;

namespace CommandNexus.Platform.Service.SyncDataServices.Http
{
    public interface ICommandDataClient
    {
        Task SendPlatformToCommand(PlatformReadDto plat);
    }
}
