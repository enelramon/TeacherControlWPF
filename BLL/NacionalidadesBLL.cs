using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeacherControlWPF.DAL;
using TeacherControlWPF.Entidades;

namespace TeacherControlWPF.BLL
{
    public class NacionalidadesBLL
    {

        public static List<Nacionalidades> GetNacionalidades()
        {
            List<Nacionalidades> lista = new List<Nacionalidades>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Nacionalidades.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

    }
}
