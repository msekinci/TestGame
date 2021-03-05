using GameFacto.TestProject.Business.Interfaces;
using GameFacto.TestProject.Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace GameFacto.TestProject.WebAPI.CustomFilters
{
    public class ValidId<TEntity> : IActionFilter where TEntity : class, IEntity, new()
    {
        private IGenericService<TEntity> _genericService;
        public ValidId(IGenericService<TEntity> genericService)
        {
            _genericService = genericService;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var dictionary = context.ActionArguments.Where(x => x.Key == "id").FirstOrDefault();
            var id = int.Parse(dictionary.Value.ToString());
            var entity = _genericService.FindByIdAsyc(id).Result;
            if (entity == null)
            {
                context.Result = new NotFoundObjectResult($"Not found any object with given {id}");
            }
        }
    }
}
