using MyVilla_VillaAPI.Models;
using System.Linq.Expressions;

namespace MyVilla_VillaAPI.Repository.IRepostiory
{
    public interface IVillaRepository : IRepository<Villa>
    {
        Task<Villa> UpdateAsync(Villa entity);
    }
}
