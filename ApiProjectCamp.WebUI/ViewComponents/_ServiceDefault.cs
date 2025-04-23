using ApiProjectCamp.WebUI.DTOs.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProjectCamp.WebUI.ViewComponents
{
    
        public class _ServiceDefault : ViewComponent
        {
            private readonly IHttpClientFactory _httpClientFactory;

            public _ServiceDefault(IHttpClientFactory httpClientFactory)
            {
                _httpClientFactory = httpClientFactory;
            }

            public async Task<IViewComponentResult> InvokeAsync()
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("https://localhost:7285/api/Services");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                    return View(values);
                }
                return View();
            }
        }
    
}
