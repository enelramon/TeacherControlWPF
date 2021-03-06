﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using TeacherControlWPF.BLL;
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
            rEstudiantes rEstudiantes = new rEstudiantes();
            rEstudiantes.Show();
        }

        private void AdicionalesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rAdicionales rAdicionales = new rAdicionales();
            rAdicionales.Show();
        }

        private void TareasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rTareas rt = new rTareas();
            rt.Show();
        }
        private void NacionalidadesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rNacionalidades rNacionalidades = new rNacionalidades();
            rNacionalidades.Show();
        }

        private void UsuariosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rUsuarios ru = new rUsuarios();
            ru.Show();
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {


            Stopwatch cronometro = new Stopwatch();
            cronometro.Start();



            await CombinacionesBLL.Insertar();//6561

            cronometro.Stop();
            MessageBox.Show(cronometro.ElapsedMilliseconds.ToString("N2"));

            //fin

        }
    }
}
