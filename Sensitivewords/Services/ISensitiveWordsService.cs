using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sensitivewords.Models;

namespace Sensitivewords.Services
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
