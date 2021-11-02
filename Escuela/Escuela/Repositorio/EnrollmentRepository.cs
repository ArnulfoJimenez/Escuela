using Escuela.Data;
using Escuela.Dominio;
using Escuela.Servicio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Repositorio
{
    public class EnrollmentRepository : IRollmennts
    {
        private ApplicationDbContext bd;

        public EnrollmentRepository(ApplicationDbContext bd)
        {
            this.bd = bd;
        }

        public List<Enrollment> UnionDeTablas()
        {
            var Union = bd.Enrollments.Include(e => e.Student).Include(c => c.Course).ToList();

            return Union;
        }
    }
}
