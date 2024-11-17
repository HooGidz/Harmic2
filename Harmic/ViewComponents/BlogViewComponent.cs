using Microsoft.AspNetCore.Mvc;
using Harmic.Models;
using Microsoft.EntityFrameworkCore;

namespace Harmic.ViewComponents
{
    public class BlogViewComponent : ViewComponent
    {
        private readonly HarmicContext _context;
        public BlogViewComponent(HarmicContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _context.TbBlogs
                .Where(m => m.IsActive) // Lọc bài viết đang hoạt động
                .OrderBy(m => m.BlogId)
                .ToListAsync();

            return View(items);
        }
    }
}
