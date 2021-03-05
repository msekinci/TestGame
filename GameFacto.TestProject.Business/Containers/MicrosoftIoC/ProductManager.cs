using GameFacto.TestProject.Business.Interfaces;
using GameFacto.TestProject.DataAccess.Interfaces;
using GameFacto.TestProject.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameFacto.TestProject.Business.Containers.MicrosoftIoC
{
    public class ProductManager : GenericManager<Product>, IProductService
    {
        private readonly IGenericDAL<Product> _genericDAL;
        private readonly IProductDAL _productDAL;
        public ProductManager(IGenericDAL<Product> genericDAL, IProductDAL productDAL) : base(genericDAL)
        {
            _genericDAL = genericDAL;
            _productDAL = productDAL;
        }

        public Task<List<Product>> GetAllByCategoryId(int categoryId)
        {
            return _productDAL.GetAllByCategoryId(categoryId);
        }
    }
}
