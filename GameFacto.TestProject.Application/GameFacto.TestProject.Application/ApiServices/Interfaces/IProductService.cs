using GameFacto.TestProject.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameFacto.TestProject.Application.ApiServices.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductList>> GetAll(int? categoryId);
    }
}
