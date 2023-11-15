using Controller;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para ViewUsers.xaml
    /// </summary>
    public partial class ViewUsers : Window
    {
        int x;
        CUsuario controller = new CUsuario();
        public ViewUsers()
        {
            InitializeComponent();
            dguser.IsReadOnly = true;
            dguser.ItemsSource = controller.GetAllUsuarios();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {

            if (Nombre.Text.Length > 1 && Apellido.Text.Length > 1 && Contrasena.Text.Length > 1 && Correo.Text.Length > 1
                && Direccion.Text.Length > 1 && Telefono.Text.Length > 1 && Tipo.Text.Length > 1)
            {
                if (Apellido.Text.Length < 50)
                {
                    if (Contrasena.Text.Length < 100 || Contrasena.Text.Length >= 8)
                    {
                        if (Correo.Text.Length < 100)
                        {
                            if (Direccion.Text.Length < 30)
                            {
                                if (Telefono.Text.Length < 30)
                                {
                                    if (Nombre.Text.Length < 50)
                                    {
                                        if (Contrasena.Text.Any(char.IsUpper) && Contrasena.Text.Any(char.IsLower) && Contrasena.Text.Any(char.IsDigit))
                                        {
                                            int type;
                                            switch (Tipo.Text)
                                            {
                                                case "Cliente Externo":
                                                    type = 1;
                                                    break;
                                                case "Cliente Interno":
                                                    type = 2;
                                                    break;
                                                case "Administrador":
                                                    type = 3;
                                                    break;
                                                case "Productor":
                                                    type = 4;
                                                    break;
                                                case "Transportista":
                                                    type = 5;
                                                    break;
                                                case "Consultor":
                                                    type = 6;
                                                    break;
                                                default:
                                                    type = 1;
                                                    break;
                                            }
                                            Usuario u = new Usuario(0, Nombre.Text, Apellido.Text, Correo.Text, Contrasena.Text, type, Direccion.Text, Telefono.Text);
                                            controller.InsertarUsuario(u);
                                        }
                                        else MessageBox.Show("Verifique que la contraseña posea carácteres en mayus, minus y números", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                    else MessageBox.Show("Verifique que el campo 'Nombre' posea máximo 50 dígitos", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                                else MessageBox.Show("Verifique que el campo 'Telefono' posea máximo 50 dígitos", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            else MessageBox.Show("Verifique que el campo 'Dirección' posea máximo 100 dígitos", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else MessageBox.Show("Verifique que el campo 'Correo' posea máximo 50 dígitos", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else MessageBox.Show("Verifique que el campo 'Contraseña' posea mínimo 8 dígitos", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else MessageBox.Show("Verifique que el campo 'Apellido' posea máximo 50 dígitos", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else MessageBox.Show("Favor rellene todos los campos", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            dguser.ItemsSource = controller.GetAllUsuarios();
        }

        private void Actualizar_Click(object sender, RoutedEventArgs e)
        {
            if (Nombre.Text.Length > 1 && Apellido.Text.Length > 1 && Contrasena.Text.Length > 1 && Correo.Text.Length > 1
                && Direccion.Text.Length > 1 && Telefono.Text.Length > 1 && Tipo.Text.Length > 1)
            {
                if (Apellido.Text.Length < 50)
                {
                    if (Contrasena.Text.Length < 100 || Contrasena.Text.Length >= 8)
                    {
                        if (Correo.Text.Length < 100)
                        {
                            if (Direccion.Text.Length < 30)
                            {
                                if (Telefono.Text.Length < 30)
                                {
                                    if (Nombre.Text.Length < 50)
                                    {
                                        if (Contrasena.Text.Any(char.IsUpper) && Contrasena.Text.Any(char.IsLower) && Contrasena.Text.Any(char.IsDigit))
                                        {
                                            int type;
                                            switch (Tipo.Text)
                                            {
                                                case "Cliente Externo":
                                                    type = 1;
                                                    break;
                                                case "Cliente Interno":
                                                    type = 2;
                                                    break;
                                                case "Administrador":
                                                    type = 3;
                                                    break;
                                                case "Productor":
                                                    type = 4;
                                                    break;
                                                case "Transportista":
                                                    type = 5;
                                                    break;
                                                case "Consultor":
                                                    type = 6;
                                                    break;
                                                default:
                                                    type = 1;
                                                    break;
                                            }
                                            Usuario u = new Usuario(x, Nombre.Text, Apellido.Text, Correo.Text, Contrasena.Text, type, Direccion.Text, Telefono.Text);
                                            controller.ActualizarUsuario(u);
                                        }
                                        else MessageBox.Show("Verifique que la contraseña posea carácteres en mayus, minus y números", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                    else MessageBox.Show("Verifique que el campo 'Nombre' posea máximo 50 dígitos", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                                else MessageBox.Show("Verifique que el campo 'Telefono' posea máximo 50 dígitos", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            else MessageBox.Show("Verifique que el campo 'Dirección' posea máximo 100 dígitos", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else MessageBox.Show("Verifique que el campo 'Correo' posea máximo 50 dígitos", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else MessageBox.Show("Verifique que el campo 'Contraseña' posea mínimo 8 dígitos", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else MessageBox.Show("Verifique que el campo 'Apellido' posea máximo 50 dígitos", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else MessageBox.Show("Favor rellene todos los campos", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            dguser.ItemsSource = controller.GetAllUsuarios();
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dguser.SelectedIndex != -1)
            {
                List<Usuario> user = controller.GetAllUsuarios();
                controller.EliminarUsuario(user[dguser.SelectedIndex].Usuarioid);
            }
            else MessageBox.Show("Favor seleccione un Usuario para eliminar", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            dguser.ItemsSource = controller.GetAllUsuarios();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dguser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dguser.SelectedIndex != -1)
            {
                List<Usuario> user = controller.GetAllUsuarios();
                x = user[dguser.SelectedIndex].Usuarioid;
                Nombre.Text = user[dguser.SelectedIndex].Nombre;
                Apellido.Text = user[dguser.SelectedIndex].Apellido;
                Correo.Text = user[dguser.SelectedIndex].Correoelectronico;
                Telefono.Text = user[dguser.SelectedIndex].Telefono;
                Contrasena.Text = user[dguser.SelectedIndex].Contrasena;
                Direccion.Text = user[dguser.SelectedIndex].Direccion;
                Tipo.SelectedIndex = (user[dguser.SelectedIndex].Tipousuarioid / 10) - 1;
            }
        }

    }
}
