using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TeacherControlWPF.Entidades
{
    public class Tareas
    {
        [Key]
        public int TareaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public float Puntos { get; set; }

        [ForeignKey("TareaId")]
        public List<TareasDetalle> Detalle { get; set; } = new List<TareasDetalle>();
    }
}
