using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeacherControlWPF.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Linq;

namespace TeacherControlWPF.BLL.Tests
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    [TestClass]
    public class EstudiantesBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            //inicio
            Stopwatch cronometro = new Stopwatch();
            cronometro.Start();

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

                            //CombinacionesBLL.Insertar(laCombinacion);//6561
                        }
                    }
                }
            }

            cronometro.Stop();
            Console.WriteLine(cronometro.ElapsedMilliseconds);

            //fin
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void CalularPromedio()
        {
            var studentList = new List<Student>
                {
                    new Student("Anthony", 20),
                    new Student("Jhan", 21),
                    new Student("Mario", 17),
                    new Student("Enel", 34)
                };

            

            double suma=0,avg=0;
            int cant=0;

            foreach (var est in studentList)
            {
                cant++;
                suma += est.Age;
            }

            avg= suma / cant;


            avg = studentList.Average(e => e.Age);

            Console.WriteLine(avg);
        }
    }
}