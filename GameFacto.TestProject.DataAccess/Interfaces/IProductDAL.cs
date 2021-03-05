using GameFacto.TestProject.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameFacto.TestProject.DataAccess.Interfaces
{
    public interface IProductDAL : IGenericDAL<Product>
    {
        Task<List<Product>> GetAllByCategoryId(int categoryId);
    }
}
