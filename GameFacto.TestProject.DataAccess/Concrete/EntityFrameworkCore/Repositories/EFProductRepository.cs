using GameFacto.TestProject.DataAccess.Concrete.EntityFrameworkCore.Context;
using GameFacto.TestProject.DataAccess.Interfaces;
using GameFacto.TestProject.Entities.Concrete;

namespace GameFacto.TestProject.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EFProductRepository : EFGenericRepository<Product>, IProductDAL
    {
        private readonly TestProjectContext _context;
        public EFProductRepository(TestProjectContext context) : base(context)
        {
            _context = context;
        }
    }
}
