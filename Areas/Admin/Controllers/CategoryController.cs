using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using YummyMvc.DAL;
using YummyMvc.Models;

namespace YummyMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            ICollection<Category> categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(error => error.ErrorMessage));
            bool isExsist = await _context.Categories.AnyAsync(c => c.Name == category.Name);
            if (isExsist)
            {
                ModelState.AddModelError("Name", " is already in exsists");
                return View(category);
            }
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
			Category? category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update( int id)
        {
            Category category = _context.Categories.Find(id);
            if (!ModelState.IsValid)
            {
                return NotFound();

            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Update(Category category)
        {
            Category cat = _context.Categories.Find(category.Id);
            if (cat == null)
            {
                return NotFound();
            }
            cat.Name = category.Name;
            _context.Categories.Update(cat);
            _context.SaveChanges();


            return RedirectToAction("Index");
        }
        //     public  IActionResult Create(Category category)
        //     {

        //         if (!ModelState.IsValid)
        //{
        //	return NotFound();
        //}
        //         return RedirectToAction("Index");
        //     }
    }
}
