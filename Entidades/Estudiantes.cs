using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TeacherControlWPF.Entidades
{
    public class Estudiantes
    {
        [Key]
        public int EstudianteId { get; set; }
        public string Matricula { get; set; } 
        public DateTime FechaIngreso { get; set; } = DateTime.Now;
        public string Nombres { get; set; }
        public int Semestre { get; set; }
        public float PuntosExtra { get; set; }
        public int NacionalidadId { get; set; }

        [ForeignKey("NacionalidadId")]
        public virtual Nacionalidades Nacionalidad { get; set; }         
    }
}
