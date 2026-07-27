namespace SunRayDesignsAPI.Data
{
    using Microsoft.EntityFrameworkCore;
    using SunRayDesignsAPI.Models;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Work> Work { get; set; }
        public DbSet<Technology> Technology{ get; set; }
        public DbSet<Quote> Quote { get; set; }
    }
}
