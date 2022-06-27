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
            if (LoadDopImages.Load(service).Length > 2)
            {
                ImagePath1.Text = LoadDopImages.Load(service)[0];
                ImagePath2.Text = LoadDopImages.Load(service)[1];
                ImagePath3.Text = LoadDopImages.Load(service)[2];
                if (ImagePath1.Text != String.Empty)
                    MiniatureTwo.Source = new ImageSourceConverter().ConvertFromString(ImagePath1.Text) as ImageSource;
                if (ImagePath2.Text != String.Empty)
                    MiniatureThree.Source = new ImageSourceConverter().ConvertFromString(ImagePath2.Text) as ImageSource;
                if (ImagePath3.Text != String.Empty)
                    MiniatureFour.Source = new ImageSourceConverter().ConvertFromString(ImagePath3.Text) as ImageSource;
            }
            else if (LoadDopImages.Load(service).Length > 1)
            {
                ImagePath1.Text = LoadDopImages.Load(service)[0];
                ImagePath2.Text = LoadDopImages.Load(service)[1];
                if (ImagePath1.Text != String.Empty)
                    MiniatureTwo.Source = new ImageSourceConverter().ConvertFromString(ImagePath1.Text) as ImageSource;
                if (ImagePath2.Text != String.Empty)
                    MiniatureThree.Source = new ImageSourceConverter().ConvertFromString(ImagePath2.Text) as ImageSource;
            }
            else if (LoadDopImages.Load(service).Length == 1)
            {
                ImagePath1.Text = LoadDopImages.Load(service)[0];
                if (ImagePath1.Text != String.Empty)
                    MiniatureTwo.Source = new ImageSourceConverter().ConvertFromString(ImagePath1.Text) as ImageSource;
            }
        }

        private void OpenImageButton_Click(object sender, RoutedEventArgs e)
        {
            ImagePathMain.Text = OpenImage.OpenFile();
            if (ImagePathMain.Text != String.Empty)
                Miniature.Source = new ImageSourceConverter().ConvertFromString(ImagePathMain.Text) as ImageSource;
            else
                Miniature.Source = new ImageSourceConverter().ConvertFromString("C:/Users/vikto/Desktop/WORK_ONE/WORK_ONE/Resourses/Images/DesignWindows/logo.png") as ImageSource;
        }
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            temp += e.Text;
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
            if (DurationText.Text != String.Empty)
                if (int.Parse(DurationText.Text) > 23)
                    DurationText.Text = "240";
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (AddOrChangeService.SaveChanges(TitleText.Text,
                CostText.Text, DurationText.Text,
                DescriptionText.Text, DiscountText.Text,
                ImagePathMain.Text, ImagePath1.Text, ImagePath2.Text, ImagePath3.Text))
                this.Close();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OpenDopOneImageButton_Click(object sender, RoutedEventArgs e)
        {
            ImagePath1.Text = OpenImage.OpenFile();
            if (ImagePath1.Text != String.Empty)
                MiniatureTwo.Source = new ImageSourceConverter().ConvertFromString(ImagePath1.Text) as ImageSource;
            else
                MiniatureTwo.Source = new ImageSourceConverter().ConvertFromString("C:/Users/vikto/Desktop/WORK_ONE/WORK_ONE/Resourses/Images/DesignWindows/logo.png") as ImageSource;
        }

        private void OpenDopTwoImageButton_Click(object sender, RoutedEventArgs e)
        {
            ImagePath2.Text = OpenImage.OpenFile();
            if (ImagePath2.Text != String.Empty)
                MiniatureThree.Source = new ImageSourceConverter().ConvertFromString(ImagePath2.Text) as ImageSource;
            else
                MiniatureThree.Source = new ImageSourceConverter().ConvertFromString("C:/Users/vikto/Desktop/WORK_ONE/WORK_ONE/Resourses/Images/DesignWindows/logo.png") as ImageSource;
        }

        private void OpenDopThreeImageButton_Click(object sender, RoutedEventArgs e)
        {
            ImagePath3.Text = OpenImage.OpenFile();
            if (ImagePath3.Text != String.Empty)
                MiniatureFour.Source = new ImageSourceConverter().ConvertFromString(ImagePath3.Text) as ImageSource;
            else
                MiniatureFour.Source = new ImageSourceConverter().ConvertFromString("C:/Users/vikto/Desktop/WORK_ONE/WORK_ONE/Resourses/Images/DesignWindows/logo.png") as ImageSource;
        }

        private void DeleteDopTwoImgButton_Click(object sender, RoutedEventArgs e)
        {
            if (ImagePath2.Text != String.Empty)
                if (!DeleteDopImage.Delete(ImagePath2.Text, service))
                    MessageBox.Show("Изображение не найдено");
                else
                {
                    ImagePath2.Text = String.Empty;
                    MiniatureThree.Source = null;
                }
        }

        private void DeleteDopOneImgButton_Click(object sender, RoutedEventArgs e)
        {
            if (ImagePath1.Text != String.Empty)
                if (!DeleteDopImage.Delete(ImagePath1.Text, service))
                    MessageBox.Show("Изображение не найдено");
                else
                {
                    ImagePath1.Text = String.Empty;
                    MiniatureTwo.Source = null;
                }
        }

        private void DeleteDopThreeImgButton_Click(object sender, RoutedEventArgs e)
        {
            if (ImagePath3.Text != String.Empty)
                if (!DeleteDopImage.Delete(ImagePath3.Text, service))
                    MessageBox.Show("Изображение не найдено");
                else
                {
                    ImagePath3.Text = String.Empty;
                    MiniatureFour.Source = null;
                }
        }
    }
}
