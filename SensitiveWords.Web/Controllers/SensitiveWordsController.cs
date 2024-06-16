using Microsoft.AspNetCore.Mvc;
using SensitiveWords.Web.Extensions;
using SensitiveWords.Web.Models;

using SensitiveWords.Web.Services;
using System.Threading.Tasks;

namespace SensitiveWords.Web.Controllers
{
    public class SensitiveWordsController : Controller
    {
        private readonly ISensitiveWordsService _sensitiveWordsService;

        public SensitiveWordsController(ISensitiveWordsService sensitiveWordsService)
        {
            _sensitiveWordsService = sensitiveWordsService;
        }

        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 10; 
            int pageNumber = page.HasValue ? page.Value : 1;
            var sensitiveWords = await _sensitiveWordsService.GetSensitiveWordsAsync();
            var paginatedList = PaginatedList<SensitiveWord>.Create(sensitiveWords, pageNumber, pageSize);
            return View(paginatedList);
        }
        public IActionResult MockChat()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
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
                await _sensitiveWordsService.UpdateSensitiveWordAsync(sensitiveWord);
                return RedirectToAction(nameof(Index));
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