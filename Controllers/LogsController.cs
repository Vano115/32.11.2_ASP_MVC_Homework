using ASP_MVC.Middlewares;
using ASP_MVC.Models.Db.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC.Controllers
{
    /// <summary>
    /// Контроллер страницы логов
    /// </summary>
    public class LogsController : Controller
    {
        // ссылка на репозиторий
        private readonly IBlogRepository _repo;

        /// <summary>
        /// LoggingMiddleware logger - если добавить это в конструктор - стреляет ошибка
        /// </summary>
        /// <param name="repo"></param>
        public LogsController(IBlogRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Возвращает страницу с логами
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var logs = await _repo.GetRequests();
            return View(logs);
        }
    }
}
