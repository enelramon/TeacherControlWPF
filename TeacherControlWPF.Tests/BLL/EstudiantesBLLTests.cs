using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeacherControlWPF.BLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace TeacherControlWPF.BLL.Tests
{
    public class EstudiantesBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {

            var Rueda1 = new string[] { "F", "B", "S", "P", "H", "M", "W", "D", "L" };
            var Rueda2 = new string[] { "Y", "H", "N", "R", "U", "A", "I", "L", "E", };
            var Rueda3 = new string[] { "O", "S", "K", "E", "N", "L", "R", "T", "A", };
            var Rueda4 = new string[] { "K", "T", "E", "D", "S", "M", "P", "Y", "L", };

            foreach (var r1 in Rueda1)
            {
                foreach (var r2 in Rueda2)
                {
                    foreach (var r3 in Rueda3)
                    {
                        foreach (var r4 in Rueda4)
                        {
                            //combinacion = r1 + r2 + r3 + r4;
                        }
                    }
                }
            }

            //"hola"
        }
    }
}