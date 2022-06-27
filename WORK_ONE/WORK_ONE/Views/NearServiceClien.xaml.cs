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
using System.Windows.Threading;
using WORK_ONE.View_Models;

namespace WORK_ONE.Views
{
    /// <summary>
    /// Логика взаимодействия для NearServiceClien.xaml
    /// </summary>
    public partial class NearServiceClien : Window
    {
        DispatcherTimer dispatcherTimer { get; set; }
        public NearServiceClien()
        {
            InitializeComponent();
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 30);
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            list_serv.ItemsSource =
                ServiceViewModel
                .LoadClientServiceList()
                .Where(x => x.clientService.StartTime.Date == DateTime.Today
                && x.clientService.StartTime.TimeOfDay > DateTime.Now.TimeOfDay)
                .OrderBy(x => x.clientService.StartTime.TimeOfDay);
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            list_serv.ItemsSource =
                ServiceViewModel
                .LoadClientServiceList()
                .Where(x => x.clientService.StartTime.Date == DateTime.Today
                && x.clientService.StartTime.TimeOfDay > DateTime.Now.TimeOfDay)
                .OrderBy(x => x.clientService.StartTime.TimeOfDay);
        }

        private void TodayButton_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Start();
            list_serv.ItemsSource =
                ServiceViewModel
                .LoadClientServiceList()
                .Where(x => x.clientService.StartTime.Date == DateTime.Today
                && x.clientService.StartTime.TimeOfDay > DateTime.Now.TimeOfDay)
                .OrderBy(x => x.clientService.StartTime.TimeOfDay);
            TodayButton.IsEnabled = false;
            TomorrowButton.IsEnabled = true;
            AllButton.IsEnabled = true;
        }

        private void TomorrowButton_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
            list_serv.ItemsSource =
                ServiceViewModel
                .LoadClientServiceList()
                .Where(x => x.clientService.StartTime.Date == DateTime.Today.AddDays(1))
                .OrderBy(x => x.clientService.StartTime.Date)
                .OrderBy(x => x.clientService.StartTime.TimeOfDay);
            TomorrowButton.IsEnabled = false;
            AllButton.IsEnabled = true;
            TodayButton.IsEnabled = true;
        }

        private void AllButton_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
            list_serv.ItemsSource =
                ServiceViewModel
                .LoadClientServiceList()
                .OrderBy(x => x.clientService.StartTime.Date)
                .OrderBy(x => x.clientService.StartTime.TimeOfDay);
            AllButton.IsEnabled = false;
            TodayButton.IsEnabled = true;
            TomorrowButton.IsEnabled = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Start();
        }
    }
}
