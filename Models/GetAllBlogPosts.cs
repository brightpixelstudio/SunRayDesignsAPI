using System;
using System.ComponentModel.DataAnnotations;

namespace SunRayDesignsAPI.Models
{
    public class GetAllBlogPosts
    {
        [Key]
        public int blogpostid { get; set; }
        public string? title { get; set; }
        public string? content { get; set; }
        public string? summary { get; set; }
        public string? url { get; set; }
        public DateTime dateposted { get; set; }
        public string? author { get; set; }
        public string? category { get; set; }
        public int blogtypeid { get; set; }
    }
}
