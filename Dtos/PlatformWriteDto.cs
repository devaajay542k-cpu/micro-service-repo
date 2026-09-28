using System.ComponentModel.DataAnnotations;

namespace platformService.Data
{
    public class PlatformWriteDto
    {

        [Required]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public string Publisher { get; set; } = string.Empty;
        
        [Required]
        public string Cost { get; set; } = string.Empty;
    }

}