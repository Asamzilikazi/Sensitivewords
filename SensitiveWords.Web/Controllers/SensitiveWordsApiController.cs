using Microsoft.AspNetCore.Mvc;
using SensitiveWords.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensitiveWords.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensitiveWordsApiController : ControllerBase
    {
        private readonly ISensitiveWordsService _sensitiveWordsService;

        public SensitiveWordsApiController(ISensitiveWordsService sensitiveWordsService)
        {
            _sensitiveWordsService = sensitiveWordsService;
        }

        [HttpGet]
        public async Task<IEnumerable<string>> GetSensitiveWords()
        {
            var sensitiveWords = await _sensitiveWordsService.GetSensitiveWordsAsync();
            return sensitiveWords.Select(sw => sw.Word);
        }
    }
}
