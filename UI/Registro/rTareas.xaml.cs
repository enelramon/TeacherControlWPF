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
using TeacherControlWPF.DAL;

namespace TeacherControlWPF.UI.Registro
{
    /// <summary>
    /// Interaction logic for rTareas.xaml
    /// </summary>
    public partial class rTareas : Window
    {
        private Tareas Tarea = new Tareas();

        public rTareas()
        {
            InitializeComponent();
            this.DataContext = Tarea;
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = Tarea;
        }

        private void Limpiar()
        {
            this.Tarea = new Tareas();
            this.DataContext = Tarea;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void AgregarFilaButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void RemoverFilaButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
