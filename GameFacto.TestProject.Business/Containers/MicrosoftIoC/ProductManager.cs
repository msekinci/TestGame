using GameFacto.TestProject.Business.Interfaces;
using GameFacto.TestProject.DataAccess.Interfaces;
using GameFacto.TestProject.Entities.Concrete;

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
    }
}
