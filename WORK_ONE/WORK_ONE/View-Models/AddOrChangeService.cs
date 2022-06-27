using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WORK_ONE.Models;

namespace WORK_ONE.View_Models
{

    public static class AddOrChangeService
    {
        public static ObservableCollection<Service> services { get; set; } = Session.Context.Service.Local;

        public static bool SaveChanges(string name, string cost,
            string duration, string description,
            string discount, string image_path)
        {
            if (name == String.Empty)
                MessageBox.Show("Введите название услуги");
            else if (cost == String.Empty)
                MessageBox.Show("Введите цену услуги");
            else if (duration == String.Empty)
                MessageBox.Show("Введите длительность услуги");
            else if (image_path == String.Empty)
                MessageBox.Show("Выберите изображение");
            else
            {
                if (discount == String.Empty)
                    discount = "0";
                image_path = image_path.Replace(@"\", "/");
                if (!services.Select(x => x.Title).Contains(name))
                {
                    services.Add(new Service
                    {
                        Title = name,
                        Cost = decimal.Parse(cost),
                        DurationInSeconds = Convert.ToInt32(duration) * 60,
                        Description = description,
                        Discount = Convert.ToDouble(discount),
                        MainImagePath = image_path
                    });
                    Session.Context.SaveChanges();
                    return true;
                }
                else
                {
                    var tochange = services.Where(x => x.Title == name).Select(x => x).FirstOrDefault();
                    tochange.Title = name;
                    tochange.Cost = decimal.Parse(cost);
                    tochange.DurationInSeconds = Convert.ToInt32(duration) * 60;
                    tochange.Description = description;
                    tochange.Discount = Convert.ToDouble(discount);
                    tochange.MainImagePath = image_path;
                    Session.Context.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        public static void DeleteService(Service service)
        {
            if (service.ClientService.Count > 0)
                MessageBox.Show("На эту услугу есть запись, удаление невозможно");
            else
            {
                services.Remove(service);
                Session.Context.SaveChanges();
            }
        }
    }
}
