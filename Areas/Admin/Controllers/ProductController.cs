using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YummyMvc.Areas.Admin.ViewModels;
using YummyMvc.DAL;
using YummyMvc.Models;

namespace YummyMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private List<Category> _categories;
        public ProductController(AppDbContext context)
        {
            _context = context;
            _categories = _context.Categories.ToList();
        }
        public IActionResult Index()
        {
            List<Product> products = _context.Products
                .Where(p=>!p.IsDeleted)
                .Include(p=>p.Category)
                .ToList();   
            return View(products);
        }
        public IActionResult Create()
        {
            CreateProductVM productVM = new CreateProductVM()
            {
                Categories = _categories
            };
            return View(productVM);
        }
    }
}
