using Microsoft.EntityFrameworkCore;
using url_shortener.Models;

namespace url_shortener.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<UrlModel> URLs { get; set; }
        
        public DbSet<TextModel> Texts { get; set; }
    }
}
