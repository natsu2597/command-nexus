using System.ComponentModel.DataAnnotations;

namespace CommandNexus.Platform.Service.Dtos
{
    public record PlatformCreatedDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public string Cost { get; set; }
    }
}
