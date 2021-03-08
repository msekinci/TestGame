using GameFacto.TestProject.Application.ApiServices.Interfaces;
using GameFacto.TestProject.Application.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GameFacto.TestProject.Application.ApiServices.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly string Url = "http://localhost:54603/api/products/";

        public async Task<List<ProductList>> GetAll(int? categoryId)
        {
            using var httpClient = new HttpClient();
            HttpResponseMessage response;
            if (categoryId.HasValue)
            {
                response = await httpClient.GetAsync(Url + "GetAllByCategoryId/" + categoryId.Value);
            }
            else
            {
                response = await httpClient.GetAsync(Url);
            }
            

            if (response.IsSuccessStatusCode)
            {
                var json = JsonConvert.DeserializeObject<List<ProductList>>(await response.Content.ReadAsStringAsync());
                return json;
            }

            return null;
        }
    }
}
