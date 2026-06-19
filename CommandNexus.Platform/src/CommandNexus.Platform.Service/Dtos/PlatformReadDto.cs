using System.ComponentModel.DataAnnotations;

namespace CommandNexus.Platform.Service.Dtos
{
    public record PlatformReadDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Publisher { get; set; }

        public string Cost { get; set; }
    }
}
