using System.ComponentModel.DataAnnotations;

namespace url_shortener.Models
{
    public class UrlModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Original Url")]
        public string OriginUrl { get; set; } = string.Empty;
        [Display(Name = "Short Url")]
        public string ShortUrl { get; set; } = string.Empty;
        [Display(Name = "Created by")]
        public string CreatedBy { get; set; } = string.Empty;
        [Display(Name = "Date of creation")]
        public DateTime DateOfCreation { get; set; } = DateTime.Now;
    }
}
