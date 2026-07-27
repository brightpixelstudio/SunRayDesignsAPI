using System.ComponentModel.DataAnnotations;

namespace SunRayDesignsAPI.Models
{
    public class Work
    {
        [Key] 
        public int workid { get; set; }
        public int number { get; set; }
        public int worktypeid { get; set; }
        public string? name { get; set; }
    }
}
