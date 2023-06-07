using AZFrontend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AZFrontend.Controllers
{

    public class Todo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Done { get; set; }
    }

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {

            HttpClient client = new();

            ViewBag.Todos = await client.GetFromJsonAsync<List<Todo>>("https://joel-backend.internal.bluesand-3e5887f9.westeurope.azurecontainerapps.io/todo") ?? Array.Empty<Todo>().ToList();

            return View();
        }

        public IActionResult Privacy()
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