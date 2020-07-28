using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeacherControlWPF.DAL;
using TeacherControlWPF.Entidades;

namespace TeacherControlWPF.BLL
{
    public class CombinacionesBLL
    {
        public static async Task<bool > Insertar( )
        {

            bool paso = false;
            Contexto contexto = new Contexto(); 

            try
            {
                string laCombinacion;
                var Rueda1 = new string[] { "F", "B", "S", "P", "H", "M", "W", "D", "L" };
                var Rueda2 = new string[] { "Y", "H", "N", "R", "U", "A", "I", "L", "E", };
                var Rueda3 = new string[] { "O", "S", "K", "E", "N", "L", "R", "T", "A", };
                var Rueda4 = new string[] { "K", "T", "E", "D", "S", "M", "P", "Y", "L", };

                foreach (var r1 in Rueda1)//9
                {
                    foreach (var r2 in Rueda2)//9^2
                    {
                        foreach (var r3 in Rueda3)//9^3
                        {
                            foreach (var r4 in Rueda4)//9^4
                            {
                                laCombinacion = r1 + r2 + r3 + r4;
                                contexto.Combinaciones.Add(new Combinaciones(laCombinacion));                                
                            }
                        }
                    }
                }

                paso = await contexto.SaveChangesAsync() > 0; 
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
