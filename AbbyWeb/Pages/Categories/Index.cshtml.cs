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
        
        public IndexModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public void OnGet()
        {
            Categories = _ctx.Category;
        }

       
    }
}
