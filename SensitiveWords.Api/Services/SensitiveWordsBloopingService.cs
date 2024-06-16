using Microsoft.EntityFrameworkCore;
using Sensitivewords.Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sensitivewords.Api.Services
{
    public class SensitiveWordsBloopingService : ISensitiveWordsBloopingService
    {
        private readonly SensitiveWordsDbContext _dbContext;

        public SensitiveWordsBloopingService(SensitiveWordsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> BloopSensitiveWordsAsync(string message)
        {
            var sensitiveWords = await GetSensitiveWordsAsync();
            var pattern = BuildRegexPattern(sensitiveWords);

            return Regex.Replace(message, pattern, match => new string('*', match.Length), RegexOptions.IgnoreCase);
        }

        private async Task<IEnumerable<string>> GetSensitiveWordsAsync()
        {
            return await _dbContext.SensitiveWords.Select(w => w.Word).ToListAsync();
        }

        private string BuildRegexPattern(IEnumerable<string> sensitiveWords)
        {
            var wordPatterns = sensitiveWords.Select(word => $@"\b{Regex.Escape(word)}\b");
            return string.Join("|", wordPatterns);
        }
    }
}
