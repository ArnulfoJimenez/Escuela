using Escuela.Data;
using Escuela.Dominio;
using Escuela.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Repositorio
{
    public class CourseRepositorio : ICourse
    {
        private ApplicationDbContext app;

        public CourseRepositorio(ApplicationDbContext app)
        {
            this.app = app; 
        }
        public void Insertar (Course c)
        {
            app.Add(c);
            app.SaveChanges();
        }
    }
}
