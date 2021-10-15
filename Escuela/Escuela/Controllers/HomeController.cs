using Escuela.Dominio;
using Escuela.Models;
using Escuela.Servicio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICourses icourse;
        public HomeController(ILogger<HomeController> logger, ICourses icourse)
        {
            this.icourse = icourse;
            _logger = logger;
        }

        public IActionResult Index()
        {
            for (int i = 0; i <= 100; i++)
            {
                Course course = new Course();

                course.Title = "Update";
                course.Credits = 100;
                icourse.Insertar(course);
            }

            return View();
        }

        public IActionResult GetAll()
        {
            var DandoFormatoJson = icourse.ListarCursos();

            return Json(new { data = DandoFormatoJson });
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
