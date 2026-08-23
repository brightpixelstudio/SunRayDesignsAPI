using System.ComponentModel.DataAnnotations;

namespace SunRayDesignsAPI.Models
{
    public class GetAllBlogTypes
    {
        [Key]
        public int blogtypeid { get; set; }
        public string? category { get; set; }
    }
}
