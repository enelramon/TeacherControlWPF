using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TeacherControlWPF.DAL;
using TeacherControlWPF.Entidades;

namespace TeacherControlWPF.BLL
{
    public class AdicionalesBLL
    {
        public static bool Guardar(Adicionales adicionales)
        {
            if (!Existe(adicionales.AdicionalId))
                return Insertar(adicionales);
            else
                return Modificar(adicionales);
        }

        /// <summary>
        /// Permite guardar una entidad en la base de datos
        /// </summary>
        /// <param name="adicionales">La entidad que se desea guardar</param>
        private static bool Insertar(Adicionales adicionales)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //Agregar la entidad que se desea insertar al contexto
                contexto.Adicionales.Add(adicionales);
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

        /// <summary>
        /// Permite modificar una entidad en la base de datos
        /// </summary>
        /// <param name="adicionales">La entidad que se desea modificar</param>
        private static bool Modificar(Adicionales adicionales)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //marcar la entidad como modificada para que el contexto sepa como proceder
                contexto.Entry(adicionales).State = EntityState.Modified;
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

        /// <summary>
        /// Permite eliminar una entidad de la base de datos
        /// </summary>
        /// <param name="id">El Id de la entidad que se desea eliminar</param> 
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //buscar la entidad que se desea eliminar
                var adicionales = AdicionalesBLL.Buscar(id);

                if (adicionales != null)
                {
                    contexto.Adicionales.Remove(adicionales); //remover la entidad
                    paso = contexto.SaveChanges() > 0;
                }

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

        /// <summary>
        /// Permite buscar una entidad en la base de datos
        /// </summary>
        /// <param name="id">El Id de la entidad que se desea buscar</param>
        public static Adicionales Buscar(int id)
        {
            Adicionales adicionales = new Adicionales();
            Contexto contexto = new Contexto();

            try
            {
                adicionales = contexto.Adicionales.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return adicionales;
        }

        /// <summary>
        /// Permite obtener una lista filtrada por un criterio de busqueda
        /// </summary>
        /// <param name="criterio">La expresión que define el criterio de busqueda</param>
        /// <returns></returns>
        public static List<Adicionales> GetList(Expression<Func<Adicionales, bool>> criterio)
        {
            List<Adicionales> Lista = new List<Adicionales>();
            Contexto contexto = new Contexto();

            try
            {
                //obtener la lista y filtrarla según el criterio recibido por parametro.
                Lista = contexto.Adicionales.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }

        /// <summary>
        /// Permite buscar si una entidad en la base de datos existe
        /// </summary>
        /// <param name="id">El Id de la entidad que se desea buscar</param>
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Adicionales.Any(e => e.AdicionalId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }
    }

}

