using Microsoft.AspNetCore.Mvc;
using url_shortener.Models;
using url_shortener.Services.AboutService;

namespace url_shortener.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IActionResult Index()
        {
            return View(_aboutService.GetText(2));
        }
        [HttpPost]
        public IActionResult Edit(TextModel obj)
        {
            _aboutService.UpdateText(obj);
            return View("Index", obj);
        }
    }
}
