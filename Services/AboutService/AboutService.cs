using url_shortener.Data;
using url_shortener.Models;

namespace url_shortener.Services.AboutService
{
    public class AboutService : IAboutService
    {
        private readonly ApplicationDbContext _db;
        public AboutService(ApplicationDbContext db)
        {
            _db = db;
        }

        public TextModel GetText(int? id)
        {
            try
            {
                return _db.Texts.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateText(TextModel obj)
        {
            try
            {
                obj.LastEdited = DateTime.Now;
                _db.Texts.Update(obj);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
