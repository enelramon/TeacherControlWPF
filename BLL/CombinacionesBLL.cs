using System;
using System.Collections.Generic;
using System.Text;
using TeacherControlWPF.DAL;
using TeacherControlWPF.Entidades;

namespace TeacherControlWPF.BLL
{
    public class CombinacionesBLL
    {
        public static bool Insertar(Combinaciones combinacion)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //Agregar la entidad que se desea insertar al contexto
                contexto.Combinaciones.Add(combinacion);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
    }
}
