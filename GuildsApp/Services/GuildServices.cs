using GuildsApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace GuildsApp.Services
{
    public class GuildServices
    {
        private readonly HttpClient _httpClient;

        public GuildServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Guild>> GetUserGuild(string apiUrl)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Dictionary<string, List<Guild>>>(responseContent);
                return result?["yourGuild"] ?? new List<Guild>();
            }
            else
            {
                Console.WriteLine("API Request failed");
            }
            return new List<Guild>();
        }

        public async Task<IEnumerable<Guild>> GetRecommendedGuild(string apiUrl)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Dictionary<string, List<Guild>>>(responseContent);
                return result?["recommendedGuild"] ?? new List<Guild>();
            }
            else
            {
                Console.WriteLine("API Request failed");
            }
            return new List<Guild>();
        }

    }
}
