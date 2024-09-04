using DotNet8WebApi.DbContextPooling.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet8WebApi.DbContextPooling.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Tbl_Blog> Tbl_Blogs { get; set; }
    }
}
