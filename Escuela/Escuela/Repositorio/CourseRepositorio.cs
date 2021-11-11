using Escuela.Data;
using Escuela.Dominio;
using Escuela.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Repositorio
{
    public class CourseRepositorio : ICourses
    {
        private ApplicationDbContext app;

        public CourseRepositorio(ApplicationDbContext app)
        {
            this.app = app; 
        }



        public void Actualizar(Course c)
        {
            app.Courses.Update(c);
        }

        public void Insertar (Course c)
        {
            app.Add(c);
            app.SaveChanges();
        }

        public void Delete(Course c)
        {
            app.Remove(c);
        }
        public void Buscar (Course c)
        {
            app.Courses.Find();

        }
        public List<Course> ListarCursos()
        {
            return app.Courses.ToList();
        }

    }
}
