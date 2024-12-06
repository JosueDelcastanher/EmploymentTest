using System.Collections.Generic;
using System.Text.Json;
using EmploymentTest.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace EmploymentTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GitHubController
    {
        [HttpGet(Name = "GetRepository")]
        public async Task<IEnumerable<Repository.Root>> GetRepositoryAsync()
        {
            // URL da API pública do GitHub ja filtrando com os 5 repositórios mais antigos.
            string baseUrl = "https://api.github.com/orgs/takenet/repos?per_page=5&Aupdated-asc"; 

            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("user-agent", "EmploymentTest");
                HttpResponseMessage response = client.GetAsync(baseUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    return await response?.Content?.ReadFromJsonAsync<IEnumerable<Repository.Root>>();
                }
            }
            catch (HttpRequestException e)
            {
                throw new HttpRequestException(e.ToString());
            }

            return new List<Repository.Root>();
        }
    }

}
