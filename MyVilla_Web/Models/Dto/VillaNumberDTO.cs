using System.ComponentModel.DataAnnotations;

namespace MyVilla_Web.Models.Dto
{
    public class VillaNumberDTO
    {
        [Required]
        public int VillNo { get; set; }
        [Required]
        public int VillaId { get; set; }
        public string? SpecialDetails { get; set; }
    }
}
