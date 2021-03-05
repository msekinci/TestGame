using GameFacto.TestProject.Entities.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameFacto.TestProject.Business.Interfaces
{
    public interface IGenericService<TEntity> where TEntity : class, IEntity, new()
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> FindByIdAsyc(int id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
    }
}
