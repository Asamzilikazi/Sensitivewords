using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using Sensitivewords.Models;
using Sensitivewords.Api.Services;

namespace Sensitivewords.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensitiveWordsBloopingController : Controller
    {
        private readonly ISensitiveWordsBloopingService _sensitiveWordsBloopingService;

        public SensitiveWordsBloopingController(ISensitiveWordsBloopingService sensitiveWordsBloopingService)
        {
            _sensitiveWordsBloopingService = sensitiveWordsBloopingService;
        }

        [HttpPost]
        public async Task<ActionResult<BloopResponse>> BloopSensitiveWords(BloopRequest request)
        {
            var bloopedMessage = await _sensitiveWordsBloopingService.BloopSensitiveWordsAsync(request.Message);
            return new BloopResponse { BloopedMessage = bloopedMessage };
        }
    }
}
