using MyVilla_Web.Models.Dto;

namespace MyVilla_Web.Services.IServices
{
    public interface IVillaNumberService
    {
        Task<T> GetALLAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(VillaNumberCreateDTO dto);
        Task<T> UpdateAsync<T>(VillaNumberUpdateDTO dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
