using Escuela.Data;
using Escuela.Dominio;
using Escuela.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Repositorio
{
    public class StudentRepository : IStudent
    {
        private ApplicationDbContext app;

        public StudentRepository(ApplicationDbContext app)
        {
            this.app = app;
        }

        public List<Student> ListOfStudent()
        {
            return app.Student.ToList();
        }
    }
}
