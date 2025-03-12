using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Entities;

namespace BakeryConsoleApp.Services
{
    public class MenuService
    {
        public async Task<List<Bread>?> GetOfficeMenuAsync(HttpClient client, int officeId)
        {
            var response = await client.GetAsync($"Offices/getMenu?officeId={officeId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<Bread>>();
            }
            return null;
        }
    }
}
