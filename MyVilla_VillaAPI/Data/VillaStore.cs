using MyVilla_VillaAPI.Models.Dto;
using System.Xml.Linq;

namespace MyVilla_VillaAPI.Data
{
    public static class VillaStore
    {
        public static readonly List<VillaDTO> villaList = new()
        {
            new VillaDTO() { Id = 1, Name = "Sun Rise View", Occupancy = 4, Sqft = 275},
            new VillaDTO() { Id = 2, Name = "Sun Set View", Occupancy = 3, Sqft = 225}
        };
    }
}
