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
    /// Interaction logic for Adicionales.xaml
    /// </summary>
    public partial class rAdicionales : Window
    {
        private Adicionales Adicional = new Adicionales();

        public rAdicionales()
        {
            InitializeComponent();
            this.DataContext = Adicional;
            EstudianteIdComboBox.ItemsSource = EstudiantesBLL.GetEstudiante();
            EstudianteIdComboBox.SelectedValuePath = "EstudianteId";
            EstudianteIdComboBox.DisplayMemberPath = "Nombres";
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = Adicional;
        }

        private void Limpiar()
        {
            this.Adicional = new Adicionales();
            this.DataContext = Adicional;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Adicionales encontrado = AdicionalesBLL.Buscar(Adicional.AdicionalId);

            if (encontrado != null)
            {
                Adicional = encontrado;
                Cargar();
                MessageBox.Show("Puntos encontrados!!", "EXITO", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                Limpiar();
                MessageBox.Show("No existe en la base de datos", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Adicionales a = AdicionalesBLL.Buscar(Adicional.AdicionalId);

            return (a != null);
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (Adicional.AdicionalId == 0)
            {
                paso = AdicionalesBLL.Guardar(Adicional);
            }
            else
            {
                if (ExisteEnLaBaseDeDatos())
                {
                    paso = AdicionalesBLL.Guardar(Adicional);
                }
                else
                {
                    MessageBox.Show("No existe en la Base de Datos", "ERROR");
                    return;
                }

                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Guardado!!", "EXITO", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No se pudo guardar...", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (AdicionalesBLL.Eliminar(Adicional.AdicionalId))
            {
                Limpiar();
                MessageBox.Show("Eliminado", "EXITO");
            }
            else
            {
                MessageBox.Show("No se pudo eliminar", "Error");
            }
        }
    }
}
