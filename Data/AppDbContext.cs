namespace SunRayDesignsAPI.Data
{
    using Microsoft.EntityFrameworkCore;
    using SunRayDesignsAPI.Models;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Work> Work { get; set; }
        public DbSet<Technology> Technology{ get; set; }
        public DbSet<Industry> Industry { get; set; }
        public DbSet<Quote> Quote { get; set; }
        public DbSet<GetAllBlogPosts> GetAllBlogPosts { get; set; }
        public DbSet<GetAllPostsCountByYear> GetAllPostsCountByYear { get; set; }
        public DbSet<GetBlogPostsBasedOnTypeAndYear> GetBlogPostsBasedOnTypeAndYear { get; set; }
        public DbSet<GetBlogPost> GetBlogPost { get; set; }
    }
}
