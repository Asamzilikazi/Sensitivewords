using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sensitivewords.Api.Services
{
    public interface ISensitiveWordsBloopingService
    {
        Task<string> BloopSensitiveWordsAsync(string message);
    }
}
