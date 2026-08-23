using System.ComponentModel.DataAnnotations;

namespace SunRayDesignsAPI.Models
{
    public class GetAllPostsCountByYearByMonth
    {
        [Key]
        public string? monthname { get; set; }
        public int year { get; set; }
        public int month { get; set; }
        public int count { get; set; }
    }
}
