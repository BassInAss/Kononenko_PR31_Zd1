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
using WORK_ONE.View_Models;

namespace WORK_ONE.Views
{
    /// <summary>
    /// Логика взаимодействия для NewServiceForm.xaml
    /// </summary>
    public partial class NewServiceForm : Window
    {
        private Service service { get; set; }
        string temp;
        public NewServiceForm()
        {
            InitializeComponent();
        }
        public NewServiceForm(Service _service)
        {
            service = _service;
            this.DataContext = service;
            InitializeComponent();
        }

        private void OpenImageButton_Click(object sender, RoutedEventArgs e)
        {
            ImagePath.Text = OpenImage.OpenFile();
            if(ImagePath.Text != String.Empty)
            Miniature.Source = new ImageSourceConverter().ConvertFromString(ImagePath.Text) as ImageSource;
            else
                Miniature.Source = new ImageSourceConverter().ConvertFromString("C:/Users/vikto/Desktop/WORK_ONE/WORK_ONE/Resourses/Images/DesignWindows/logo.png") as ImageSource;
        }
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            temp += e.Text;
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
            if(DurationText.Text != String.Empty)
            if (int.Parse(DurationText.Text) > 23)
                DurationText.Text = "240";
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (AddOrChangeService.SaveChanges(TitleText.Text,
                CostText.Text, DurationText.Text,
                DescriptionText.Text, DiscountText.Text,
                ImagePath.Text))
                this.Close();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
