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

            // Asignar la instancia del al formulario para usarla en BINDINGS
            this.DataContext = Estudiante;

            //Cargar las nacionalidades al ComboBox
            NacionalidadesComboBox.ItemsSource = NacionalidadesBLL.GetNacionalidades();
            NacionalidadesComboBox.SelectedValuePath = "NacionalidadId";
            NacionalidadesComboBox.DisplayMemberPath = "Nacionalidad";
        }

        private void Limpiar()
        {
            this.Estudiante = new Estudiantes();
            this.DataContext = Estudiante;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (NombresTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var estudiante = EstudiantesBLL.Buscar(Utilidades.ToInt(EstudianteIdTextBox.Text));

            if (Estudiante != null)
                this.Estudiante = estudiante;
            else
                this.Estudiante = new Estudiantes();

            this.DataContext = this.Estudiante;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = EstudiantesBLL.Guardar(Estudiante);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transaccione exitosa!", "Exito", 
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Transaccion Fallida", "Fallo", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (EstudiantesBLL.Eliminar(Utilidades.ToInt(EstudianteIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado!", "Exito", 
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

    }
}
