using GameFacto.TestProject.Application.ApiServices.Interfaces;
using GameFacto.TestProject.Application.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GameFacto.TestProject.Application.ApiServices.Concrete
{
    public class CategoryManager : ICategoryApiService
    {
        private readonly string Url = "http://localhost:54603/api/categories/";
        
        public async Task<List<CategoryList>> GetCategoriesMenuItems(int? categoryId)
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(Url + "getcategories/" + categoryId);

            if (response.IsSuccessStatusCode)
            {
                var json =  JsonConvert.DeserializeObject<List<CategoryList>>(await response.Content.ReadAsStringAsync());
                return json;
            }
            return null;
        }
    }
}
