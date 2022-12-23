using url_shortener.Models;

namespace url_shortener.Services.AboutService
{
    public interface IAboutService
    {
        public TextModel GetText(int? id);
        public void UpdateText(TextModel obj);
    }
}
