using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Data;
using System.Linq;
using TeacherControlWPF.DAL;

namespace TeacherControlWPF.BLL
{
    public class LoginBLL
    {
        public static bool Validar(string nombreusuario, string contrasena)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var ls = from l in db.Usuarios
                         where l.NombreUsuario == nombreusuario
                         && l.Contrasena == GetSHA256(contrasena)
                         select l;
                if (ls.Count() > 0)
                {
                    paso = true;
                }
                else paso = false;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
    }
}
