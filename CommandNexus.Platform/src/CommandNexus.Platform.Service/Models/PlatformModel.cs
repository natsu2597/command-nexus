using System.ComponentModel.DataAnnotations;

namespace CommandNexus.Platform.Service.Models
{
    public class PlatformModel : IModel
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public string Cost { get; set; }

    }
}
