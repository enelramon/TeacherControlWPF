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

namespace TeacherControlWPF.UI.Login
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        Usuarios usuarios = new Usuarios();
        MainWindow Principal = new MainWindow();

        public Login()
        {
            InitializeComponent();
        }

        private void Inicio()
        {

            bool paso = LoginBLL.Validar(usuarios.NombreUsuario, usuarios.Contrasena);

            if (paso)
            {
                Close();
                Principal.Show();
            }
            else
            {
                MessageBox.Show("Error de Autenticacion!", "Error!");
            }
        }

        private void IngresarButton_Click(object sender, RoutedEventArgs e)
        {
            Inicio();
        }
    }
}
