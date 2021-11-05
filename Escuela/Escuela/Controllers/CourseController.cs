using Escuela.Dominio;
using Escuela.Repositorio;
using Escuela.Servicio;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Controllers
{
    public class CourseController : Controller
    {
        private readonly ILogger<CourseController> _logger;
        private ICourses icourse;
        public CourseController(ILogger<CourseController> logger, ICourses icourse)
        {
            this.icourse = icourse;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Guardar (Course c)
        {

            if (ModelState.IsValid)
            {
                icourse.Insertar(c);
                return View();
            }
            else
            {
                return View("Guardar", c);
            }
            
        }
        public IActionResult GetAll()
        {
            var DandoFormatoJson = icourse.ListarCursos();

            return Json(new { data = DandoFormatoJson });
        }
    }
}
