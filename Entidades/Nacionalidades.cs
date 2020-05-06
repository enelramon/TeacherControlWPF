using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeacherControlWPF.Entidades
{
    public class Nacionalidades
    {
        [Key]
        public int NacionalidadId { get; set; }
        public string Nacionalidad { get; set; }
    }
}
