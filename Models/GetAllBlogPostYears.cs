using System.ComponentModel.DataAnnotations;

namespace SunRayDesignsAPI.Models
{
    public class GetAllBlogPostYears
    {
        [Key]
        public int UniqueYear { get; set; }
    }
}
