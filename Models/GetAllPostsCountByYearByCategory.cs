using System.ComponentModel.DataAnnotations;

namespace SunRayDesignsAPI.Models
{
    public class GetAllPostsCountByYearByCategory
    {
        [Key]
        public int blogtypeid { get; set; }
        public string? category  { get; set; }
        public int count { get; set; }
    }
}

