using SensitiveWords.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SensitiveWords.Web.Services
{
    public interface ISensitiveWordsService
    {
        Task<IEnumerable<SensitiveWord>> GetSensitiveWordsAsync();
        Task<SensitiveWord> GetSensitiveWordAsync(int id);
        Task CreateSensitiveWordAsync(SensitiveWord sensitiveWord);
        Task UpdateSensitiveWordAsync(SensitiveWord sensitiveWord);
        Task DeleteSensitiveWordAsync(int id);
    }
}