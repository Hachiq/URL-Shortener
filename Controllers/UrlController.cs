using Microsoft.AspNetCore.Mvc;
using System.Data;
using url_shortener.Models;
using url_shortener.Services.UrlService;

namespace url_shortener.Controllers
{
    public class UrlController : Controller
    {
        private readonly IUrlService _urlService;
        public UrlController(IUrlService urlService)
        {
            _urlService = urlService;
        }
        public IActionResult Index()
        {
            return View(_urlService.GetUrls());
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(UrlModel url)
        {
            IEnumerable<UrlModel> urls = _urlService.GetUrls();
            foreach (var record in urls)
            {
                if (record.OriginUrl.Equals(url.OriginUrl))
                {
                    ModelState.AddModelError("OriginUrl", "Such URL already exists in database");
                }
            }
            if (ModelState.IsValid)
            {
                _urlService.AddUrl(url);
                return RedirectToAction("Index");
            }
            return View(url);
        }

        public IActionResult Info(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var url = _urlService.GetUrlById(id);

            if (url == null)
            {
                return NotFound();
            }

            return View(url);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            return View(_urlService.GetUrlById(id));
        }

        [HttpPost]
        public IActionResult Delete(UrlModel url)
        {
            if (ModelState.IsValid)
            {
                _urlService.RemoveUrl(url);
                return RedirectToAction("Index");
            }

            return View(url);
        }
    }
}
