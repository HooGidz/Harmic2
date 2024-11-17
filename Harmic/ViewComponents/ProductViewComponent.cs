using Microsoft.AspNetCore.Mvc;
using Harmic.Models;
using Microsoft.EntityFrameworkCore;

namespace Harmic.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        private readonly HarmicContext _context;
        public ProductViewComponent(HarmicContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _context.TbProducts
                .Include(m => m.CategoryProduct)
                .Where(m => m.IsActive == true && m.IsNew)
                .OrderBy(m => m.ProductId)
                .ToListAsync();

            return View(items);
        }
    }
}
