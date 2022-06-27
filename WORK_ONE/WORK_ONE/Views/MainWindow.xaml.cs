using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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
using WORK_ONE.View_Models;

namespace WORK_ONE.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string temp = String.Empty;
        public List<Service> current_filter { get; set; }
        public List<Service> current_find { get; set; }
        private int counter = 0;
        public MainWindow(string isAdmin)
        {
            InitializeComponent();
            current_find = ServiceViewModel.LoadList();
            current_filter = ServiceViewModel.LoadList();
            list_serv.ItemsSource = ServiceViewModel.LoadList();
            CountService.Content = $"Выведено {list_serv.Items.Count} записей из {ServiceViewModel.LoadList().Count}";
            if (isAdmin == "0000")
                ISADMIN.Content = "Admin";
            else
                ISADMIN.Content = "User";
            DiscountComboFilter.ItemsSource = LoadToCombo.DiscountComboLoad();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AuthPage auth = new AuthPage();
            auth.Show();
        }

        private void AddServiceButton_Click(object sender, RoutedEventArgs e)
        {
            NewServiceForm serviceForm = new NewServiceForm();
            serviceForm.ShowDialog();
            list_serv.ItemsSource = ServiceViewModel.LoadList();
            current_find = ServiceViewModel.LoadList();
            current_filter = ServiceViewModel.LoadList();
            CountService.Content = $"Выведено {current_filter.Where(x => x.Title.Contains(temp)).Count() + 1} записей из {ServiceViewModel.LoadList().Count}";
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            NewServiceForm serviceForm = new NewServiceForm((Service)list_serv.SelectedItem);
            serviceForm.ShowDialog();
            list_serv.ItemsSource = ServiceViewModel.LoadList();
            current_find = ServiceViewModel.LoadList();
            current_filter = ServiceViewModel.LoadList();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            AddOrChangeService.DeleteService((Service)list_serv.SelectedItem);
            list_serv.ItemsSource = ServiceViewModel.LoadList();
            current_find = ServiceViewModel.LoadList();
            current_filter = ServiceViewModel.LoadList();
            CountService.Content = $"Выведено {current_filter.Where(x => x.Title.Contains(temp)).Count()} записей из {ServiceViewModel.LoadList().Count}";
        }

        private void DiscountComboFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (DiscountComboFilter.SelectedIndex)
            {
                case 0:
                    list_serv.ItemsSource = ServiceViewModel.LoadList();
                    current_filter = current_find;
                    break;
                case 1:
                    list_serv.ItemsSource = current_find.Where(x => x.Discount < 5);
                    current_filter = ServiceViewModel.LoadList().Where(x => x.Discount < 5).ToList();
                    break;
                case 2:
                    list_serv.ItemsSource = current_find.Where(x => x.Discount > 4 && x.Discount < 15);
                    current_filter = ServiceViewModel.LoadList().Where(x => x.Discount > 4 && x.Discount < 15).ToList();
                    break;
                case 3:
                    list_serv.ItemsSource = current_find.Where(x => x.Discount > 14 && x.Discount < 30);
                    current_filter = ServiceViewModel.LoadList().Where(x => x.Discount > 14 && x.Discount < 30).ToList();
                    break;
                case 4:
                    list_serv.ItemsSource = current_find.Where(x => x.Discount > 29 && x.Discount < 70);
                    current_filter = ServiceViewModel.LoadList().Where(x => x.Discount > 29 && x.Discount < 70).ToList();
                    break;
                case 5:
                    list_serv.ItemsSource = current_find.Where(x => x.Discount > 69 && x.Discount < 100);
                    current_filter = ServiceViewModel.LoadList().Where(x => x.Discount > 69 && x.Discount < 100).ToList();
                    break;
                default:
                    break;
            }
            CountService.Content = $"Выведено {current_filter.Where(x => x.Title.Contains(temp)).Count()} записей из {ServiceViewModel.LoadList().Count}";
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (temp.IndexOf(" ") == 0)
            {
                temp = String.Empty;
                Find.Text = temp;
            }
            temp += e.Text;
            list_serv.ItemsSource = current_filter.Where(x => x.Title.Contains(temp));
            current_find = ServiceViewModel.LoadList().Where(x => x.Title.Contains(temp)).ToList();
            CountService.Content = $"Выведено {current_filter.Where(x => x.Title.Contains(temp)).Count()} записей из {ServiceViewModel.LoadList().Count}";
        }

        private void Find_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                temp += " ";
            }
            if (Find.Text == String.Empty)
            {
                temp = string.Empty;
            }
            if (temp.IndexOf(" ") == 0)
            {
                temp = String.Empty;
                Find.Text = temp;
            }
            if (e.Key == Key.Delete || e.Key == Key.Back)
                if (temp.Length > 1)
                {
                    temp = temp.Remove(temp.Length - 1);
                    list_serv.ItemsSource = current_filter.Where(x => x.Title.Contains(temp));
                    current_find = ServiceViewModel.LoadList().Where(x => x.Title.Contains(temp)).ToList();
                }
                else
                {
                    temp = String.Empty;
                    list_serv.ItemsSource = current_filter;
                    current_find = ServiceViewModel.LoadList();
                }
            CountService.Content = $"Выведено {current_filter.Where(x => x.Title.Contains(temp)).Count()} записей из {ServiceViewModel.LoadList().Count}";
        }

        private void SortLabel_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (counter % 2 == 0)
            {
                if (temp != string.Empty)
                {
                    list_serv.ItemsSource = current_filter.OrderBy(x => x.Cost).Where(x => x.Title.Contains(temp));
                }
                else
                {
                    list_serv.ItemsSource = current_filter.OrderBy(x => x.Cost);
                }
                SortLabel.Content = "Сортировать по цене ↑";
            }
            else
            {
                if (temp != string.Empty)
                {
                    list_serv.ItemsSource = current_filter.OrderByDescending(x => x.Cost).Where(x => x.Title.Contains(temp));
                }
                else
                {
                    list_serv.ItemsSource = current_filter.OrderByDescending(x => x.Cost);
                }
                SortLabel.Content = "Сортировать по цене ↓";
            }
            counter++;
            CountService.Content = $"Выведено {current_filter.Where(x => x.Title.Contains(temp)).Count()} записей из {ServiceViewModel.LoadList().Count}";
        }

        private void AddClientToService_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AddClientToService clientToService = new AddClientToService((Service)list_serv.SelectedItem);
            clientToService.ShowDialog();
            list_serv.ItemsSource = ServiceViewModel.LoadList();
        }

        private void CloseClientToService_Click(object sender, RoutedEventArgs e)
        {
            NearServiceClien nearServiceClien = new NearServiceClien();
            nearServiceClien.Show();
        }
    }
}
