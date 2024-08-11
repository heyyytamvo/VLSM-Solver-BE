using System.ComponentModel.DataAnnotations;

namespace MyAPI.Models
{
    public class InputSubnet
    {
        [Required]
        public int order { get; set; }

        [Required]
        public int numberOfHost { get; set; }
    }
}