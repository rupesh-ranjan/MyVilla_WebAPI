using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyVilla_VillaAPI.Data;
using MyVilla_VillaAPI.Models;
using MyVilla_VillaAPI.Repository.IRepostiory;
using System.Linq.Expressions;

namespace MyVilla_VillaAPI.Repository
{
    public class VillaRepository : Repository<Villa>, IVillaRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public VillaRepository(ApplicationDbContext dbContext) :base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Villa> UpdateAsync(Villa entity)
        {
            _dbContext.Villas.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
