using MyVilla_Web.Models;
using MyVilla_Web.Models.Dto;

namespace MyVilla_Web.Services.IServices
{
    public interface IAuthService
    {
        Task<T> LoginAsync<T>(LoginRequestDTO loginRequestDTO);
        Task<T> RegisterAsync<T>(RegisterationRequestDTO registerationRequestDTO);
    }
}
