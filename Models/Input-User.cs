using System.ComponentModel.DataAnnotations;

namespace MyAPI.Models
{
    public class InputUser
    {
        [Required]
        public string? majorNetwork { get; set; }

        [Required]
        public List<InputSubnet> ListOfSubnets { get; set; }
    }
}