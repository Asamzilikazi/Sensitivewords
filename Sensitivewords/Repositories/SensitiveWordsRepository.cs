using Microsoft.EntityFrameworkCore;
using Sensitivewords.Data;
using Sensitivewords.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sensitivewords.Repositories
{
    public class SensitiveWordsRepository : ISensitiveWordsRepository
    {
        private readonly SensitiveWordsDbContext _dbContext;

        public SensitiveWordsRepository(SensitiveWordsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SensitiveWord>> GetAllAsync()
        {
            return await _dbContext.SensitiveWords.ToListAsync();
        }

        public async Task<SensitiveWord> GetByIdAsync(int id)
        {
            return await _dbContext.SensitiveWords.FindAsync(id);
        }

        public async Task AddAsync(SensitiveWord sensitiveWord)
        {
            _dbContext.SensitiveWords.Add(sensitiveWord);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(SensitiveWord sensitiveWord)
        {
            _dbContext.Entry(sensitiveWord).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var sensitiveWord = await _dbContext.SensitiveWords.FindAsync(id);
            if (sensitiveWord != null)
            {
                _dbContext.SensitiveWords.Remove(sensitiveWord);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
