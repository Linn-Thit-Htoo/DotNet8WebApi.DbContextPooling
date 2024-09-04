using DotNet8WebApi.DbContextPooling.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNet8WebApi.DbContextPooling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetBlogs(CancellationToken cancellationToken)
        {
            var blogs = await _context.Tbl_Blogs.OrderByDescending(x => x.BlogId).ToListAsync(cancellationToken: cancellationToken);
            return Ok(blogs);
        }
    }
}
