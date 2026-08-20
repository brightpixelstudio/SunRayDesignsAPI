using System.ComponentModel.DataAnnotations;

namespace SunRayDesignsAPI.Models
{
    public class GetAllPostsCountByYear
    {
        [Key]
        public string? month { get; set; }
        public int year { get; set; }
        public int count { get; set; }
    }
}
