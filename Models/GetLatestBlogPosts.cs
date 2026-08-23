using System.ComponentModel.DataAnnotations;

namespace SunRayDesignsAPI.Models
{
    public class GetLatestBlogPosts
    {
        [Key]
        public int blogpostid { get; set; }
        public string? title { get; set; }
        public string? url{ get; set; }
        public DateTime dateposted { get; set; }
        public string? summary { get; set; }        
    }
}
