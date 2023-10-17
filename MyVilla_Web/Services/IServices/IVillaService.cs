﻿using MyVilla_Web.Models.Dto;

namespace MyVilla_Web.Services.IServices
{
    public interface IVillaService
    {
        Task<T> GetALLAsync<T>(string token);
        Task<T> GetAsync<T>(int id, string token);
        Task<T> CreateAsync<T>(VillaCreateDTO dto, string token);
        Task<T> UpdateAsync<T>(VillaUpdateDTO dto, string token);
        Task<T> DeleteAsync<T>(int id, string token);
    }
}
