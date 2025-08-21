using ASP_MVC.Models.Db;
using ASP_MVC.Models.Db.Repository;

namespace ASP_MVC.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private IBlogRepository _repository;

        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddleware(RequestDelegate next, IBlogRepository repository)
        {
            _next = next;
            _repository = repository;
        }

        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            Request request = new Request()
            {
                Date = DateTime.Now,
                Url = $"{context.Request.Host.Value + context.Request.Path}"
            };

            // Для логирования данных о запросе используем свойста объекта HttpContext
            string logMessage = $"[{request.Date}]: New request to http://{request.Url}\n";
            Console.WriteLine(logMessage);

            // Путь до лога (опять-таки, используем свойства IWebHostEnvironment)
            string logFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Logs", "RequestLog.txt");

            // Сохраняем логи в БД
            await _repository.AddRequest(request);

            // Используем асинхронную запись в файл
            await File.AppendAllTextAsync(logFilePath, logMessage);

            // Передача запроса далее по конвейеру
            await _next.Invoke(context);
        }
    }
}
