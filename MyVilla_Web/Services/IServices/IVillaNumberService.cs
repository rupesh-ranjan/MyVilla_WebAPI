using MyVilla_Web.Models.Dto;

namespace MyVilla_Web.Services.IServices
{
    public interface IVillaNumberService
    {
        Task<T> GetALLAsync<T>(string token);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> CreateAsync<T>(VillaNumberCreateDTO dto, string token);
        Task<T> UpdateAsync<T>(VillaNumberUpdateDTO dto, string token);
        Task<T> DeleteAsync<T>(int id, string token);
    }
}
