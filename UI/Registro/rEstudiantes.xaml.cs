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

            this.DataContext = Estudiante;

            //Cargar las nacionalidades al ComboBox

        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            this.Estudiante = new Estudiantes();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
