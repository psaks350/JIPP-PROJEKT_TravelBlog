using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TravelBlog.Models;
using TravelBlog.Repository;


namespace TravelBlog.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        private readonly BlogManager _manager;
        public HomeController(BlogManager manager)
        {
            _manager = manager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Omnie()
        {
            return View();
        }
        public IActionResult Aktualnosci()
        {
            return View();
        }
        public IActionResult Galeria()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Kontakt()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Kontakt(EmailModel AddresEmail)
        {
            if (ModelState.IsValid)
            {
                await _manager.AddEmailAsync(AddresEmail);
                return RedirectToAction("FormSubmitted");
            }

            return View(AddresEmail);
        }
        public IActionResult FormSubmitted()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
