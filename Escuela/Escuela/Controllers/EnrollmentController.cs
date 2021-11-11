using Escuela.Dominio;
using Escuela.Servicio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Controllers
{
    public class EnrollmentController : Controller
    {
        public readonly ILogger<EnrollmentController> _logger;
        private ICourses icourse;
        private IRollmennts irollmennts;
        private IStudent istudent;



        public EnrollmentController(ILogger<EnrollmentController> logger, ICourses icourse,
            IRollmennts irollmennts, IStudent istudent)
        {
            this.icourse = icourse;
            this.irollmennts = irollmennts;
            this.istudent = istudent;
            _logger = logger;
        }

        public IActionResult Lista()
        {
            var listado = irollmennts.UnionDeTablas();
            return View(listado);
        }

        public IActionResult Guardar(Enrollment E)
        {

            var infromationOftheCombo = icourse.ListarCursos();
            var infromationOftheComboforStudents = istudent.ListOfStudent();

            List<SelectListItem> listcourse = new List<SelectListItem>();
            List<SelectListItem> liststudent = new List<SelectListItem>();

            foreach (var iterarinformation in infromationOftheCombo)
            {
                listcourse.Add(
                    new SelectListItem
                    {
                        Text = iterarinformation.Title,
                        Value = Convert.ToString(iterarinformation.CourseID)


                    }
                    );

                ViewBag.estadolistcourse = listcourse;
            }

            foreach (var iterarinformation in infromationOftheComboforStudents)
            {
                liststudent.Add(
                    new SelectListItem
                    {
                        Text = iterarinformation.LastName,
                        Value = Convert.ToString(iterarinformation.StudentID)


                    }
                    );

                ViewBag.estadoliststudent = liststudent;
                
            }

            return View();


           



        }

public IActionResult GetInformationComboBox(Enrollment E)
        {

            return View("Guardar");
        }

        public IActionResult GetAllForJoinJsonLinq()
        {

            var listado = irollmennts.UnionDeTablas();

            var Combinaciondearreglos = (from union in listado
                                         select new
                                         {
                                             union.EnrollmentID,
                                             union.CourseID,
                                             union.StudentID,
                                             union.Course.Title,
                                             union.Student.LastName,
                                             union.Grade
                                         }).ToList();

            return Json(new { Combinaciondearreglos });
        }
    }
}

