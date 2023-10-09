using MyVilla_Web.Models.Dto;

namespace MyVilla_Web.Services.IServices
{
    public interface IVillaService
    {
        Task<T> GetALLAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(VillaCreateDTO dto);
        Task<T> UpdateAsync<T>(VillaUpdateDTO dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
