using MyVilla_VillaAPI.Models;
using System.Linq.Expressions;

namespace MyVilla_VillaAPI.Repository.IRepostiory
{
    public interface IVillaNumberRepository : IRepository<VillaNumber>
    {
        Task<VillaNumber> UpdateAsync(VillaNumber entity);
    }
}
