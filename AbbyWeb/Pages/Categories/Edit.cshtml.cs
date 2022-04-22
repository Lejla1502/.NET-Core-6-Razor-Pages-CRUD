using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _ctx;

        public Category Category { get; set; }
        public EditModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public void OnGet(int id)
        {
            Category = _ctx.Category.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString())
                ModelState.AddModelError("Category.Name", "name and order can't be the same");
            if (ModelState.IsValid)
            {
                _ctx.Category.Update(Category);
                await _ctx.SaveChangesAsync();

                return RedirectToPage("Index");
            }

            return Page();

        }
    }
}
