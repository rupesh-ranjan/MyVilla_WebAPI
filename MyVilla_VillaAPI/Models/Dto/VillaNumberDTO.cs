﻿using System.ComponentModel.DataAnnotations;

namespace MyVilla_VillaAPI.Models.Dto
{
    public class VillaNumberDTO
    {
        [Required]
        public int VillNo { get; set; }
        public string? SpecialDetails { get; set; }
    }
}