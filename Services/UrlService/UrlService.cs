using url_shortener.Data;
using url_shortener.Models;

namespace url_shortener.Services.UrlService
{
    public class UrlService : IUrlService
    {
        private readonly string baseUrl = "https://localhost:44363";
        private readonly ApplicationDbContext _db;
        public UrlService(ApplicationDbContext db)
        {
            _db = db;
        }
        public void AddUrl(UrlModel url)
        {
            try
            {
                url.ShortUrl = CreateShortUrl();
                url.CreatedBy = "User";
                _db.URLs.Add(url);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UrlModel GetUrlById(int? id)
        {
            return _db.URLs.Find(id);
        }

        public IEnumerable<UrlModel> GetUrls()
        {
            return _db.URLs.ToList();
        }

        public void RemoveUrl(UrlModel url)
        {
            try
            {
                _db.URLs.Remove(url);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string GetUrlHash()
        {
            string b62 = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string hash = "";
            for (int i = 0; i < 8; i++)
            {
                hash += b62[new Random().Next(0, b62.Length)];
            }
            return hash;
        }

        public string CreateShortUrl()
        {
            return baseUrl + "/" + GetUrlHash();
        }
    }
}
