using Escuela.Data;
using Escuela.Dominio;
using Escuela.Models;
using Escuela.Servicio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
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
        
        


        public CourseController(ILogger<CourseController> logger, ICourses icourse, 
            IRollmennts irollmennts)
        {
            this.icourse = icourse;
            this.irollmennts = irollmennts;
            
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Guardar(Course c)
        {

            if (ModelState.IsValid)
            {
                icourse.Insertar(c);
                ViewBag.message = "Se ha guardado";

                return View("Listado");
            }
            else
            {
                return View("Guardar", c);
            }

        }
        
        //public IActionResult Eliminar(Course c)
        //{
        //    icourse.Delete(c);
            
            
               
           
        //    return View();
        //}

        public IActionResult Listado(Course c)
        {

            var listado = icourse.ListarCursos();

            return View(listado);

        
        }

        public IActionResult Edit( Course c)
        {
            icourse.Actualizar(c);

            return View();
        }

        
        public IActionResult GetAll()
        {
            var DandoFormatoJson = icourse.ListarCursos();

            return Json(new { data = DandoFormatoJson });
        }

       
    }

   
}

