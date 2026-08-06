using System.ComponentModel.DataAnnotations;

namespace SunRayDesignsAPI.Models
{
    public class Industry
    {
        [Key]
        public int industryid { get; set; }
        public string? name { get; set; }
    }
}
