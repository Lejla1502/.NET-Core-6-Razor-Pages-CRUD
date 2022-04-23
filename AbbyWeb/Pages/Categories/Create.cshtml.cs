using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _ctx;
        public Category Category { get; set; }
        public CreateModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString())
                ModelState.AddModelError("Category.Name", "name and order can't be the same");
            if (ModelState.IsValid)
            {
                await _ctx.Category.AddAsync(Category);
                await _ctx.SaveChangesAsync();
                TempData["success"] = "Successfully created category";
                return RedirectToPage("Index");
            }

            return Page();

        }
    }
}
