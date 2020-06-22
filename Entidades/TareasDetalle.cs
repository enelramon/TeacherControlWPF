using System.ComponentModel.DataAnnotations;

namespace TeacherControlWPF.Entidades
{
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
