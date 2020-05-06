using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeacherControlWPF.Entidades
{
    public class Adicionales
    {
        [Key]
        public int AdicionalId { get; set; }
        public DateTime Fecha { get; set; }
        public int EstudianteId { get; set; }
        public float Puntos { get; set; }
    }
}
