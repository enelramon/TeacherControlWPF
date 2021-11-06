using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using TeacherControlWPF.BLL;
using TeacherControlWPF.Entidades;

namespace TeacherControlWPF.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cEstudiantes.xaml
    /// </summary>
    public partial class cEstudiantes : Window
    {
        public cEstudiantes()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Estudiantes>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //EstudianteId
                        listado = EstudiantesBLL.GetList(e => e.EstudianteId == Utilidades.ToInt(CriterioTextBox.Text));
                        break;

                    case 1: //Nombres                       
                        listado = EstudiantesBLL.GetList(e => e.Nombres.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        break;
                }
            }
            else
            {
                listado = EstudiantesBLL.GetList(c => true);
            }

            if (DesdeDataPicker.SelectedDate != null)
                listado = EstudiantesBLL.GetList(c => c.FechaIngreso.Date >= DesdeDataPicker.SelectedDate);
                        
            if (HastaDatePicker.SelectedDate != null)
                listado = EstudiantesBLL.GetList(c => c.FechaIngreso.Date <= HastaDatePicker.SelectedDate);

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;

            var monto = listado.Sum(x => x.PuntosExtra );
        }


    }
}

