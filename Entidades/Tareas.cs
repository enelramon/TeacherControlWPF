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

    public class TareasDetalle
    {
        [Key]
        public int Id { get; set; }
        public int TareaId { get; set; }
        public string Requerimiento { get; set; }
        public float Valor { get; set; }

        public TareasDetalle(int tareaId, string requerimiento, float valor)
        {
            Id = 0;
            TareaId = tareaId;
            Requerimiento = requerimiento;
            Valor = valor;
        }
    }
}
