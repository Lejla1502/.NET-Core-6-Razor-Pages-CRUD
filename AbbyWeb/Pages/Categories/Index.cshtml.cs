using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _ctx;
        public IEnumerable<Category> Categories { get; set; }  
        public Category Category { get; set; }
        public IndexModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public void OnGet()
        {
            Categories = _ctx.Category;
        }

        public IActionResult OnPostDelete(int id)
        {
            if (id == 0 | id == null)
                return NotFound();

            Category = _ctx.Category.Find(id);
            _ctx.Category.Remove(Category);
            _ctx.SaveChanges();
            return RedirectToPage("Index");

        }
    }
}
