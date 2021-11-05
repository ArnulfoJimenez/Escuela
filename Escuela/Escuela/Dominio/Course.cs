using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Dominio
{
    public class Course
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int CourseID { get; set; }


        [Display(Name = "Title")]
        [Required(ErrorMessage = "Campo requerido")]
        public string Title { get; set; }


        [Display(Name = "Credits")]
        [Range(0, int.MaxValue, ErrorMessage = "Campo requerido")]
        public int Credits { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}