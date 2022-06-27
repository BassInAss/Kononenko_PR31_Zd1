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
using System.Windows.Shapes;
using WORK_ONE.Models;

namespace WORK_ONE.View_Models
{
    /// <summary>
    /// Логика взаимодействия для AddClientToService.xaml
    /// </summary>
    public partial class AddClientToService : Window
    {
        private Service service { get; set; }
        public string temp;
        public AddClientToService(Service _service)
        {
            service = _service;
            this.DataContext = service;
            InitializeComponent();
            Date.DisplayDateStart = DateTime.Now;
            ClientsCombo.ItemsSource = LoadClientsToCombo.ClientsComboLoad();
        }

        private void AddClientService_Click(object sender, RoutedEventArgs e)
        {
            if (AddClientServiceViewModel.AddClient(service, ClientsCombo.SelectedItem.ToString(), AddTime.Text, Date.SelectedDate))
            {
                MessageBox.Show("Запись прошла успешно");
                this.Close();
            }
        }

        private void AddTime_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (" 1234567890".IndexOf(e.Text) > 0)
            {
                if (AddTime.Text == String.Empty)
                {
                    temp = String.Empty;
                    if (int.Parse(e.Text) > 2)
                        e.Handled = true;
                }
                else if (temp.Length == 1)
                {
                    if (temp == "2")
                        if (int.Parse(e.Text) > 3)
                            e.Handled = true;
                        else
                        {
                            e.Handled = true;
                            AddTime.Text = temp + e.Text + ":";
                            temp = AddTime.Text;
                            AddTime.CaretIndex = AddTime.Text.Length;
                        }
                    else
                    {
                        e.Handled = true;
                        AddTime.Text = temp + e.Text + ":";
                        temp = AddTime.Text;
                        AddTime.CaretIndex = AddTime.Text.Length;
                    }
                }
                else if (temp.Length == 3)
                    if (int.Parse(e.Text) > 5)
                        e.Handled = true;
                if (e.Handled == false && temp.Length < 5)
                    temp += e.Text;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void AddTime_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (temp != null && temp.Length > 1)
                if (e.Key == Key.Delete || e.Key == Key.Back)
                {
                    if (temp.Contains(':'))
                        if (temp.IndexOf(':') == temp.Length - 1)
                        {
                            temp = temp.Remove(temp.Length - 2, 2);
                            AddTime.Text = temp;
                        }
                        else
                        {
                            temp = temp.Remove(temp.Length - 1);
                        }
                    else
                        temp = temp.Remove(temp.Length - 1);
                }
        }

        private void AddTime_TextChanged(object sender, TextChangedEventArgs e)
        {
            AddTime.Text = AddTime.Text.Replace(" ", string.Empty);
            AddTime.SelectionStart = AddTime.Text.Length; // возврат каретки в конец текста
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
