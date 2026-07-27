using System.ComponentModel.DataAnnotations;

namespace SunRayDesignsAPI.Models
{
    public class Quote
    {
        [Key]
        public int quoteid { get; set; }
        public string? quote { get; set; }
        public string? user { get; set; }
    }
}
