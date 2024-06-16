using Microsoft.AspNetCore.Mvc;
using Sensitivewords.Models;
using Sensitivewords.Services;
using System.Threading.Tasks;

namespace Sensitivewords.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensitiveWordsController : Controller
    {
        private readonly ISensitiveWordsService _sensitiveWordsService;

        public SensitiveWordsController(ISensitiveWordsService sensitiveWordsService)
        {
            _sensitiveWordsService = sensitiveWordsService;
        }

        public async Task<IActionResult> Index()
        {
            var sensitiveWords = await _sensitiveWordsService.GetSensitiveWordsAsync();
            return View(sensitiveWords);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SensitiveWord sensitiveWord)
        {
            if (ModelState.IsValid)
            {
                await _sensitiveWordsService.CreateSensitiveWordAsync(sensitiveWord);
                return RedirectToAction(nameof(Index));
            }
            return View(sensitiveWord);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sensitiveWord = await _sensitiveWordsService.GetSensitiveWordAsync(id.Value);
            if (sensitiveWord == null)
            {
                return NotFound();
            }
            return View(sensitiveWord);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SensitiveWord sensitiveWord)
        {
            if (id != sensitiveWord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _sensitiveWordsService.UpdateSensitiveWordAsync(sensitiveWord);
                }
                catch
                {
                    // Handle the exception if needed
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sensitiveWord);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sensitiveWord = await _sensitiveWordsService.GetSensitiveWordAsync(id.Value);
            if (sensitiveWord == null)
            {
                return NotFound();
            }

            return View(sensitiveWord);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sensitiveWord = await _sensitiveWordsService.GetSensitiveWordAsync(id.Value);
            if (sensitiveWord == null)
            {
                return NotFound();
            }

            return View(sensitiveWord);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _sensitiveWordsService.DeleteSensitiveWordAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}