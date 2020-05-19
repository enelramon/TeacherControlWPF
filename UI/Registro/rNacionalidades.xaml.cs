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
    /// Interaction logic for rNacionalidades.xaml
    /// </summary>
    public partial class rNacionalidades : Window
    {
        private Nacionalidades Nacionalidad;

        public rNacionalidades()
        {
            InitializeComponent();
            this.Nacionalidad = new Nacionalidades();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var encontrado = NacionalidadesBLL.Buscar(int.Parse(NacionalidadIdTextBox.Text));

            if (encontrado != null)
            {
                this.Nacionalidad = encontrado;

                this.DataContext = encontrado;
            }

            else
                this.Nacionalidad = new Nacionalidades();


        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
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
