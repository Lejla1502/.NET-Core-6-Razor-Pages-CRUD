using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _ctx;
        public Category Category { get; set; }

        public DeleteModel(ApplicationDbContext ctx)
        {
            _ctx= ctx;
        }
        public void OnGet(int id)
        {
            Category = _ctx.Category.Find(id);
        }
    }
}
