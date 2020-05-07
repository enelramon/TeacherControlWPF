using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TeacherControlWPF.BLL;
using TeacherControlWPF.Entidades;

namespace TeacherControlWPF.UI.Registro
{
    /// <summary>
    /// Interaction logic for REstudiante.xaml
    /// </summary>
    public partial class rEstudiantes : Window
    {
        private Estudiantes Estudiante = new Estudiantes();

        public rEstudiantes()
        {
            InitializeComponent();

            this.DataContext = Estudiante;  //Cargar las nacionalidades al ComboBox

            EstudianteIdTextBox.Text = "0"; //Se inicializa el Textbox en 0

        }
            
        private void Cargar() //Se cargan los datos de los Estudiantes
        {
            this.DataContext = null;
            this.DataContext = Estudiante;
        }

        private void Limpiar() //Se limpian los datos contenidos en los elementos
        {
            EstudianteIdTextBox.Text = "0";
            FechaIngresoDataPicker.Text = string.Empty;
            NombresTextBox.Text = string.Empty;
            SemestreTextBox.Text = string.Empty;
            PuntosExtrasTextBox.Text = string.Empty;
            NacionalidadesComboBox.Text = string.Empty;
            this.Estudiante = new Estudiantes();
            Cargar();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)//Se buscan los datos de los estudiantes mediante el Id
        {
            Estudiantes es = EstudiantesBLL.Buscar(Estudiante.EstudianteId);
            
            if(es != null)
            {
                Estudiante = es;
                Cargar();
            }
            else
            {
                MessageBox.Show("No se encontro", "ERROR");
            }
        }
        

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar(); 
            
        }

        private bool ExisteEnLaBaseDeDatos() //Aqui verifica si existe un estudiante en la base de datos mediante el Id
        {
            Estudiantes e = EstudiantesBLL.Buscar(Estudiante.EstudianteId);

            return (e != null);
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e) 
        {
            bool paso = false;

            if (Estudiante.EstudianteId == 0) // Se verifica si el id del estudiante es igual a 0
            {
                paso = EstudiantesBLL.Guardar(Estudiante); // Se guardan los datos 
            }
            else
            {
                if (ExisteEnLaBaseDeDatos()) //Si el Id no es 0 se verifica si se guardo en la BLL
                {
                    paso = EstudiantesBLL.Modificar(Estudiante);
                }
                else
                {
                    MessageBox.Show("No existe en la Base de Datos","ERROR");
                    return;
                }

                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Guardado!!", "Exito");
                }
                else
                {
                    MessageBox.Show("No se pudo Guardar","ERROR");
                }
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (EstudiantesBLL.Eliminar(Estudiante.EstudianteId))
            {
                Limpiar();
                MessageBox.Show("Eliminado","EXITO");
            }
            else
            {
                MessageBox.Show("No se pudo eliminar", "Error");
            }
        }

    }
}
