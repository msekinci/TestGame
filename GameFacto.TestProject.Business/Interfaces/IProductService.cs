using GameFacto.TestProject.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameFacto.TestProject.Business.Interfaces
{
    public interface IProductService : IGenericService<Product>
    {
        Task<List<Product>> GetAllByCategoryId(int categoryId);
    }
}
