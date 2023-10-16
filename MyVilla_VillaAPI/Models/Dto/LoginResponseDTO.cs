using MyVilla_VillaApi.Models;

namespace MyVilla_VillaAPI.Models.Dto
{
    public class LoginResponseDTO
    {
        public LocalUser User { get; set; }
        public string Token { get; set; }
    }
}
