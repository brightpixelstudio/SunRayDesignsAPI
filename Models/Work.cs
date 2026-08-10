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
        public string? url { get; set; }
        public string? content { get; set; }
        public string? title { get; set; }
    }
}
