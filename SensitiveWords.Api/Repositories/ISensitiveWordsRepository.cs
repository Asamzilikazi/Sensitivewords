using SensitiveWords.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sensitivewords.Api.Repositories
{
    public interface ISensitiveWordsRepository
    {
        Task<IEnumerable<SensitiveWord>> GetAllAsync();
        Task<SensitiveWord> GetByIdAsync(int id);
        Task AddAsync(SensitiveWord sensitiveWord);
        Task UpdateAsync(SensitiveWord sensitiveWord);
        Task DeleteAsync(int id);
    }
}
