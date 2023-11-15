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
    /// Lógica de interacción para ViewContracts.xaml
    /// </summary>
    public partial class ViewContracts : Window
    {
        CUsuario controller_user = new CUsuario();
        CContrato controller_con = new CContrato();
        int x = new int();
        public ViewContracts()
        {
            InitializeComponent();
            salidacli.IsReadOnly = true;
            salidacli.ItemsSource = controller_user.GetAllUsuarios();
            salidacon.IsReadOnly = true;
            salidacon.ItemsSource = controller_con.GetAllContratos();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int quantity;
            bool idcheck = int.TryParse(Id.Text, out id);
            bool qcheck = int.TryParse(Cantidad.Text, out quantity);
            List<Usuario> user = controller_user.GetAllUsuarios();
            List<int> ids = new List<int>();
            foreach (Usuario u in user){
                ids.Add(u.Usuarioid);
            }
            if (Id.Text.Length >= 1 && Cantidad.Text.Length >= 1 && Demanda.Text.Length >= 1 && TipoContrato.Text.Length >= 1
                && Inicio.Text.Length >= 1 && Fin.Text.Length >= 1 && EstadoContrato.Text.Length >= 1)
            {
                if (idcheck && ids.Contains(id))
                {
                    if (qcheck)
                    {
                        if (Demanda.Text.Length < 100)
                        {
                            if (Inicio.SelectedDate < Fin.SelectedDate)
                            {
                                int estado;
                                switch (EstadoContrato.Text)
                                {
                                    case "Vigente":
                                        estado = 1;
                                        break;
                                    case "Vencido":
                                        estado = 0;
                                        break;
                                    case "Completado":
                                        estado = 2;
                                        break;
                                    case "Terminado":
                                        estado = 3;
                                        break;
                                    case "Pendiente":
                                        estado = 4;
                                        break;
                                    default:
                                        estado = 1;
                                        break;
                                }
                                Contrato c = new Contrato(0, Convert.ToDateTime(Inicio.SelectedDate), Convert.ToDateTime(Fin.SelectedDate), TipoContrato.Text, estado, Demanda.Text, quantity, id, 0);
                                controller_con.InsertarContrato(c);
                            }
                            else MessageBox.Show("La fecha de fin no puede ser anterior a la fecha de inicio", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else MessageBox.Show("Verifique que el campo 'Demanda' posea máximo 100 dígitos", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else MessageBox.Show("Verifique que el campo 'Cantidad' sea numérico", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else MessageBox.Show("Verifique que el campo 'ID' posea sólo números y se encuentre disponible en la lista de usuarios", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else MessageBox.Show("Favor rellene todos los campos", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            salidacon.ItemsSource = controller_con.GetAllContratos();
        }

        private void Actualizar_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int quantity;
            bool idcheck = int.TryParse(Id.Text, out id);
            bool qcheck = int.TryParse(Cantidad.Text, out quantity);
            List<Usuario> user = controller_user.GetAllUsuarios();
            List<int> ids = new List<int>();
            foreach (Usuario u in user)
            {
                ids.Add(u.Usuarioid);
            }
            if (Id.Text!="" && Cantidad.Text!= "" && Demanda.Text!= "" && TipoContrato.Text!= ""
                && Inicio.SelectedDate.HasValue && Fin.SelectedDate.HasValue && EstadoContrato.Text!= "")
            {
                if (idcheck && ids.Contains(id))
                {
                    if (qcheck)
                    {
                        if (Demanda.Text.Length < 100)
                        {
                            if (Inicio.SelectedDate < Fin.SelectedDate)
                            {
                                if (salidacon.SelectedIndex != -1)
                                {
                                    int estado;
                                    switch (EstadoContrato.Text)
                                    {
                                        case "Vigente":
                                            estado = 1;
                                            break;
                                        case "Vencido":
                                            estado = 0;
                                            break;
                                        case "Completado":
                                            estado = 2;
                                            break;
                                        case "Terminado":
                                            estado = 3;
                                            break;
                                        case "Pendiente":
                                            estado = 4;
                                            break;
                                        default:
                                            estado = 1;
                                            break;
                                    }
                                    Contrato c = new Contrato(x, Convert.ToDateTime(Inicio.SelectedDate), Convert.ToDateTime(Fin.SelectedDate), TipoContrato.Text, estado, Demanda.Text, quantity, id, 0);
                                    controller_con.ActualizarContrato(c);
                                }
                                else MessageBox.Show("Favor seleccionar un campo", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

                            }
                            else MessageBox.Show("La fecha de fin no puede ser anterior a la fecha de inicio", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else MessageBox.Show("Verifique que el campo 'Demanda' posea máximo 100 dígitos", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else MessageBox.Show("Verifique que el campo 'Cantidad' sea numérico", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else MessageBox.Show("Verifique que el campo 'ID' posea sólo números y se encuentre disponible en la lista de usuarios", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else MessageBox.Show("Favor rellene todos los campos", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            salidacon.ItemsSource = controller_con.GetAllContratos();
        }


        private void salidacli_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (salidacli.SelectedIndex != -1)
            {
                List<Usuario> user = controller_user.GetAllUsuarios();
                Id.Text = user[salidacli.SelectedIndex].Usuarioid.ToString();
            }
        }

        private void salidacon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (salidacon.SelectedIndex != -1)
            {
                List<Contrato> con = controller_con.GetAllContratos();
                x = con[salidacon.SelectedIndex].Contratoid;
                Id.Text = con[salidacon.SelectedIndex].Usuarioid.ToString();
                Cantidad.Text = con[salidacon.SelectedIndex].Cantidad.ToString();
                Demanda.Text = con[salidacon.SelectedIndex].Demanda;
                switch (con[salidacon.SelectedIndex].Tipocontrato)
                {
                    case "Contrato de Productor":
                        TipoContrato.SelectedItem = 1;
                        break;
                    case "Contrato de Demanda":
                        TipoContrato.SelectedItem = 2;
                        break;
                    default:
                        TipoContrato.SelectedItem = 0;
                        break;
                }
                switch (con[salidacon.SelectedIndex].Estadocontratoid)
                {
                    case 1:
                        EstadoContrato.SelectedItem = 1;
                        break;
                    case 0:
                        EstadoContrato.SelectedItem = 2;
                        break;
                    case 2:
                        EstadoContrato.SelectedItem = 3;
                        break;
                    case 3:
                        EstadoContrato.SelectedItem = 4;
                        break;
                    case 4:
                        EstadoContrato.SelectedItem = 5;
                        break;
                    default:
                        EstadoContrato.SelectedItem = 0;
                        break;
                }
                Inicio.SelectedDate = con[salidacon.SelectedIndex].Fechainicio;
                Fin.SelectedDate = con[salidacon.SelectedIndex].Fechafinalizacion;
            }
        }

        private void Publicar_Click(object sender, RoutedEventArgs e)
        {
            int z;
            List<Contrato> con = controller_con.GetAllContratos();
           
            switch (con[salidacon.SelectedIndex].Tipocontrato)
            {
                case "Contrato de Productor":
                    z = 1;
                    break;
                case "Contrato de Demanda":
                    z = 2;
                    break;
                default:
                    z = 0;
                    break;
            }

            if(z == 2)
            {
                if (con[salidacon.SelectedIndex].Published == 0)
                {
                    x = con[salidacon.SelectedIndex].Contratoid;
                    controller_con.PublicarContrato(x,1);

                }
                else MessageBox.Show("El contrato ya se encuentra publicado", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else MessageBox.Show("No se puede publicar un contrato que no sea de demanda", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            salidacon.ItemsSource = controller_con.GetAllContratos();
        }
    }

}
