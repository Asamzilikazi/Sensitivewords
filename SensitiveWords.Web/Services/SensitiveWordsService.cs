using SensitiveWords.Web.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SensitiveWords.Web.Services
{
    public class SensitiveWordsService : ISensitiveWordsService
    {
        private readonly HttpClient _httpClient;

        public SensitiveWordsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<SensitiveWord>> GetSensitiveWordsAsync()
        {
            var response = await _httpClient.GetAsync("/api/SensitiveWords");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<SensitiveWord>>();
        }

        public async Task<SensitiveWord> GetSensitiveWordAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/SensitiveWords/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<SensitiveWord>();
        }

        public async Task CreateSensitiveWordAsync(SensitiveWord sensitiveWord)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/SensitiveWords", sensitiveWord);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateSensitiveWordAsync(SensitiveWord sensitiveWord)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/SensitiveWords/{sensitiveWord.Id}", sensitiveWord);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteSensitiveWordAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/SensitiveWords/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}