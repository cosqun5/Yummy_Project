using YummyMvc.Models;

namespace YummyMvc.Areas.Admin.ViewModels
{
    public class CreateProductVM
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public IFormFile Photo { get; set; }
        public bool IsDeleted { get; set; }

        public int? CategoryId { get; set; }
        public List< Category>? Categories { get; set; }
    }
}
