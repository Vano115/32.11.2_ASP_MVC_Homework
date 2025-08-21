using System.Diagnostics;
using ASP_MVC.Models;
using ASP_MVC.Models.Db;
using ASP_MVC.Models.Db.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC.Controllers
{
    public class HomeController : Controller
    {
        // ������ �� �����������
        private readonly IBlogRepository _repo;
        private readonly ILogger<HomeController> _logger;

        // ����� ������� ������������� � �����������
        public HomeController(ILogger<HomeController> logger, IBlogRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }


        // ������� ����� �����������
        public async Task<IActionResult> Index()
        {
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
