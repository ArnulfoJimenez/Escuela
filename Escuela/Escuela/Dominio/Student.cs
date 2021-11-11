using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Dominio
{
    public class Student
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentID { get; set; }

        [Display(Name = "LastName")]
        [Required(ErrorMessage = "Campo requerido")]
        public string LastName { get; set; }

        [Display(Name = "FirstMidName")]
        [Required(ErrorMessage = "Campo requerido")]
        public string FirstMidName { get; set; }

        [Display(Name = "EnrollmentsDate")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Campo requerido")]
        public DateTime EnrollmentsDate { get; set; }

        public List<Enrollment> Enrollment { get; set; }
    }
}
