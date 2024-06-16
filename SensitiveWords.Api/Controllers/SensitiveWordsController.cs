using Microsoft.AspNetCore.Mvc;
using Sensitivewords.Api.Services;
using Sensitivewords.Models;
using SensitiveWords.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sensitivewords.Api.Controllers
{
    [Route("api/SensitiveWords")]
    [ApiController]
    public class SensitiveWordsController : ControllerBase
    {
        private readonly ISensitiveWordsService _sensitiveWordsService;

        public SensitiveWordsController(ISensitiveWordsService sensitiveWordsService)
        {
            _sensitiveWordsService = sensitiveWordsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SensitiveWord>>> GetSensitiveWords()
        {
            var sensitiveWords = await _sensitiveWordsService.GetSensitiveWordsAsync();
            return Ok(sensitiveWords);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SensitiveWord>> GetSensitiveWord(int id)
        {
            var sensitiveWord = await _sensitiveWordsService.GetSensitiveWordAsync(id);
            if (sensitiveWord == null)
            {
                return NotFound();
            }
            return Ok(sensitiveWord);
        }

        [HttpPost]
        public async Task<ActionResult<SensitiveWord>> CreateSensitiveWord(SensitiveWord sensitiveWord)
        {
            await _sensitiveWordsService.CreateSensitiveWordAsync(sensitiveWord);
            return CreatedAtAction(nameof(GetSensitiveWord), new { id = sensitiveWord.Id }, sensitiveWord);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSensitiveWord(int id, SensitiveWord sensitiveWord)
        {
            if (id != sensitiveWord.Id)
            {
                return BadRequest();
            }

            await _sensitiveWordsService.UpdateSensitiveWordAsync(sensitiveWord);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSensitiveWord(int id)
        {
            var existingSensitiveWord = await _sensitiveWordsService.GetSensitiveWordAsync(id);
            if (existingSensitiveWord == null)
            {
                return NotFound();
            }

            await _sensitiveWordsService.DeleteSensitiveWordAsync(id);
            return NoContent();
        }
    }
}