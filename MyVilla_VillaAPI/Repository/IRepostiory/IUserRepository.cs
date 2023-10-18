using MyVilla_VillaApi.Models;
using MyVilla_VillaAPI.Models.Dto;

namespace MyVilla_VillaAPI.Repository.IRepostiory
{
    public interface IUserRepository
    {
        bool ISUniqueUser (string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<UserDTO> Register(RegisterationRequestDTO registerationRequestDTO);
    }
}
