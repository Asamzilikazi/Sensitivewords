using Microsoft.EntityFrameworkCore;
using Sensitivewords.Data;
using Sensitivewords.Models;
using Sensitivewords.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sensitivewords.Services
{
    public class SensitiveWordsService : ISensitiveWordsService
    {
        private readonly ISensitiveWordsRepository _repository;

        public SensitiveWordsService(ISensitiveWordsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SensitiveWord>> GetSensitiveWordsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<SensitiveWord> GetSensitiveWordAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreateSensitiveWordAsync(SensitiveWord sensitiveWord)
        {
            await _repository.AddAsync(sensitiveWord);
        }

        public async Task UpdateSensitiveWordAsync(SensitiveWord sensitiveWord)
        {
            await _repository.UpdateAsync(sensitiveWord);
        }

        public async Task DeleteSensitiveWordAsync(int id)
        {
            await _repository.DeleteAsync(id);
           
        }
    }
}
