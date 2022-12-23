using url_shortener.Models;

namespace url_shortener.Services.UrlService
{
    public interface IUrlService
    {
        IEnumerable<UrlModel> GetUrls();
        UrlModel GetUrlById(int? id);
        public void AddUrl(UrlModel url);
        public void RemoveUrl(UrlModel url);
        public string GetUrlHash();
        public string CreateShortUrl();
    }
}
