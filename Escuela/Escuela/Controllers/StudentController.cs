using Escuela.Dominio;
using Escuela.Servicio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Controllers
{
    public class StudentController : Controller
    {

        public readonly ILogger<StudentController> _logger;
        private ICourses icourse;
        private IRollmennts irollmennts;
        private IStudent istudent;



        public StudentController(ILogger<StudentController> logger, ICourses icourse,
            IRollmennts irollmennts, IStudent istudent)
        {
            this.icourse = icourse;
            this.irollmennts = irollmennts;
            this.istudent = istudent;
            _logger = logger;
        }

        public IActionResult Agregar(Student s)
        {
            if (ModelState.IsValid)
            {
                istudent.Agregar(s);

                return View();
            }
            else
            {
                return View("Agregar", s);
            }
        }

        public IActionResult Listado(Student s)
        {
            var listado = istudent.ListOfStudent();

            return View(listado);
        }

        public IActionResult GetAll()
        {
            var DandoFormatoJson = istudent.ListOfStudent();

            return Json(new { data = DandoFormatoJson });
        }
    }
}
