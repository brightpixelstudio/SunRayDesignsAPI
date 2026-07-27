using System.ComponentModel.DataAnnotations;

namespace SunRayDesignsAPI.Models
{
    public class Technology
    {
        [Key]
        public int technologyid { get; set; }
        public string? image { get; set; }
        public string? url { get; set; }        
        public string? name { get; set; }        
        public string? technologytypename { get; set; }
    }
}
