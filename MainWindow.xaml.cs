using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TeacherControlWPF.UI.Consultas;
using TeacherControlWPF.UI.Registro;

namespace TeacherControlWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

       
        private void EstudianteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rEstudiantes re = new rEstudiantes();
            re.Show();
        }

        private void AdicionalesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rAdicionales ra = new rAdicionales();
            ra.Show();
        }

        private void TareasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rTareas rt = new rTareas();
            rt.Show();
        }

        private void ConsultaEstudianteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cEstudiantes ce = new cEstudiantes();
            ce.Show();

        }

        private void ConsultaAdicionalesMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ConsultaTareasMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
