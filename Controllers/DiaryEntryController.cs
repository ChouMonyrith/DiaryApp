using DiaryApp.Data;
using DiaryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiaryApp.Controllers
{
    public class DiaryEntryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DiaryEntryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<DiaryEntry> diaryEntries = _context.DiaryEntries.ToList();

            return View(diaryEntries);
        }

        public IActionResult Show(int id)
        {
            var diaryEntries = _context.DiaryEntries.Find(id);
            if (diaryEntries == null)
            {
                return NotFound();
            }
            return View(diaryEntries);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Store(DiaryEntry diaryEntry)
        {
            _context.DiaryEntries.Add(diaryEntry);
            _context.SaveChanges();

            return RedirectToAction("Index", "DiaryEntry");
        }
        
         
        public IActionResult Edit(int id)
        {
            var diaryEntry = _context.DiaryEntries.Find(id);

            if (diaryEntry == null)
            {
                return NotFound();
            }

            _context.SaveChanges();

            return View("Edit", diaryEntry);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(DiaryEntry diaryEntry)
        {
            if (diaryEntry != null)
            {
                _context.DiaryEntries.Update(diaryEntry);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(diaryEntry);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var entryToDelete = _context.DiaryEntries.Find(id);
            if (entryToDelete != null)
            {
                _context.DiaryEntries.Remove(entryToDelete);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound();
        }




    }
}
