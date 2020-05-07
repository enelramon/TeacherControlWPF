using System;
using System.Collections.Generic;
using System.Text;
using TeacherControlWPF.Entidades;
using TeacherControlWPF.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace TeacherControlWPF.BLL
{
    public class TareasBLL
    {
        public static bool Guardar(Tareas tarea)
        {
            if (!Existe(tarea.TareaId))//si no existe insertamos
                return Insertar(tarea);
            else
                return Modificar(tarea);
        }

        /// <summary>
        /// Permite guardar una entidad en la base de datos
        /// </summary>
        /// <param name="tarea">La entidad que se desea guardar</param>
        private static bool Insertar(Tareas tarea)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //Agregar la entidad que se desea insertar al contexto
                contexto.Tareas.Add(tarea);
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
        /// <param name="tarea">La entidad que se desea modificar</param>
        private static bool Modificar(Tareas tarea)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //busca la entidad en la base de datos y la elimina
                contexto.Database.ExecuteSqlRaw($"Delete FROM TareasDetalle Where TareaId={tarea.TareaId}");

                foreach(var item in tarea.Detalle)
                {
                    contexto.Entry(item).State = EntityState.Added;
                }

                //marcar la entidad como modificada para que el contexto sepa como proceder
                contexto.Entry(tarea).State = EntityState.Modified;
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
                var tarea = TareasBLL.Buscar(id);

                if (tarea != null)
                {
                    contexto.Tareas.Remove(tarea); //remover la entidad
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
        public static Tareas Buscar(int id)
        {
            Tareas tarea = new Tareas();
            Contexto contexto = new Contexto();

            try
            {
                tarea = contexto.Tareas.Include(x => x.Detalle)
                    .Where(x => x.TareaId == id)
                    .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return tarea;
        }

        /// <summary>
        /// Permite obtener una lista filtrada por un criterio de busqueda
        /// </summary>
        /// <param name="criterio">La expresión que define el criterio de busqueda</param>
        /// <returns></returns>
        public static List<Tareas> GetList(Expression<Func<Tareas, bool>> criterio)
        {
            List<Tareas> Lista = new List<Tareas>();
            Contexto contexto = new Contexto();

            try
            {
                //obtener la lista y filtrarla según el criterio recibido por parametro.
                Lista = contexto.Tareas.Where(criterio).ToList();
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
                encontrado = contexto.Tareas.Any(e => e.TareaId == id);
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
