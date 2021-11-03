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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICourses icourse;
        private IRollmennts irollmennts;
        public HomeController(ILogger<HomeController> logger, ICourses icourse,
            IRollmennts irollmennts)
        {
            this.icourse = icourse;
            this.irollmennts = irollmennts;
            _logger = logger;
        }

        public IActionResult Index()
        {
            //for (int i = 0; i <= 100; i++)
            //{
            var listado = irollmennts.UnionDeTablas();

            return View(listado);
        }

        public IActionResult GetAll()
        {
            var DandoFormatoJson = icourse.ListarCursos();

            return Json(new { data = DandoFormatoJson });
        }

        public IActionResult Union()
        {
            var listado = irollmennts.UnionDeTablas();

            return View(listado);
        }

        public IActionResult GetAllForJoinJsonLinq()
        {

            var listado = irollmennts.UnionDeTablas();

            var Combinaciondearreglos = (from union in listado
                                         select new
                                         {
                                             union.Course.Title,
                                             union.Student.LastName,
                                             union.Student.FirstMidName,
                                             union.Grade
                                         }).ToList();

            return Json (new { Combinaciondearreglos});
        }
        public IActionResult ComboBox()
        {

            var infromationOftheCombo = icourse.ListarCursos();
            List<SelectListItem> lista = new List<SelectListItem>();

            foreach(var iterarinformation in infromationOftheCombo)
            {
                lista.Add(
                    new SelectListItem
                    {
                        Text = iterarinformation.Title,
                        Value = Convert.ToString(iterarinformation.CourseID)


                    }
                    );

                ViewBag.Estado = lista;
            }



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
