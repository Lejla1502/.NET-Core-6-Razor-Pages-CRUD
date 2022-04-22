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
            if (ModelState.IsValid)
            {
                await _ctx.Category.AddAsync(Category);
                await _ctx.SaveChangesAsync();

                return RedirectToPage("Index");
            }

            return Page();

        }
    }
}
