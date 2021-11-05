using Escuela.Dominio;
using Escuela.Models;
using Escuela.Servicio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Controllers
{
    public class CourseController : Controller
    {
        public readonly ILogger<CourseController> _logger;
        private ICourses icourse;
        private IRollmennts irollmennts;
        private IStudent istudent;


        public CourseController(ILogger<CourseController> logger, ICourses icourse, 
            IRollmennts irollmennts, IStudent istudent)
        {
            this.icourse = icourse;
            this.irollmennts = irollmennts;
            this.istudent = istudent;
            _logger = logger;
        }

        public IActionResult Guardar(Course c)
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

        public IActionResult Listado()
        {
            return View();
        }

        //public IActionResult GetAllForJoinJsonLinq()
        //{

        //    var listado = irollmennts.UnionDeTablas();

        //    var Combinaciondearreglos = (from union in listado
        //                                 select new
        //                                 {
        //                                     union.Course.Title,
        //                                     union.Student.LastName,
        //                                     union.Student.FirstMidName,
        //                                     union.Grade
        //                                 }).ToList();

        //    return Json(new { Combinaciondearreglos });
        //}

        public IActionResult GetAll()
        {
            var DandoFormatoJson = icourse.ListarCursos();

            return Json(new { data = DandoFormatoJson });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

   
}

