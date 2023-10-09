using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyVilla_VillaAPI.Data;
using MyVilla_VillaAPI.Models;
using MyVilla_VillaAPI.Repository.IRepostiory;
using System.Linq.Expressions;

namespace MyVilla_VillaAPI.Repository
{
    public class VillaNumberRepository : Repository<VillaNumber>, IVillaNumberRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public VillaNumberRepository(ApplicationDbContext dbContext) :base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<VillaNumber> UpdateAsync(VillaNumber entity)
        {
            _dbContext.VillaNumbers.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
