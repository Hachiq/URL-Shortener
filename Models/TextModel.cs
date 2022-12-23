namespace url_shortener.Models
{
    public class TextModel
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public DateTime LastEdited { get; set; }
    }
}
