using System.Windows;
using TeacherControlWPF.BLL;
using TeacherControlWPF.Entidades;

namespace TeacherControlWPF.UI.Registro
{
    public partial class rEstudiantes : Window
    {
        private Estudiantes Estudiante = new Estudiantes();

        public rEstudiantes()
        {
            InitializeComponent();

            this.DataContext = Estudiante;
            //Cargar las nacionalidades al ComboBox

            //Cargar las nacionalidades al ComboBox
            NacionalidadesComboBox.ItemsSource = NacionalidadesBLL.GetNacionalidades();
            NacionalidadesComboBox.SelectedValuePath = "NacionalidadId";
            NacionalidadesComboBox.DisplayMemberPath = "Nacionalidad";
        }
            
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = Estudiante;
        }

        private void Limpiar()
        {
            this.Estudiante = new Estudiantes();
            this.DataContext = Estudiante;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)//Se buscan los datos de los estudiantes mediante el Id
        {
            Estudiantes encontrado = EstudiantesBLL.Buscar(Estudiante.EstudianteId);

            if (encontrado != null)
            {
                Estudiante = encontrado;
                Cargar();
                MessageBox.Show("Estudiante encontrado!!", "EXITO", MessageBoxButton.OK, MessageBoxImage.Information);
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
            Estudiantes e = EstudiantesBLL.Buscar(Estudiante.EstudianteId);

            return (e != null);
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (Estudiante.EstudianteId == 0)
            {
                paso = EstudiantesBLL.Guardar(Estudiante);
            }
            else
            {
                if (ExisteEnLaBaseDeDatos())
                {
                    paso = EstudiantesBLL.Guardar(Estudiante);
                }
                else
                {
                    MessageBox.Show("No existe en la Base de Datos", "ERROR");
                    return;
                }

                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Transaccione exitosa!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (EstudiantesBLL.Eliminar(Estudiante.EstudianteId))
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
