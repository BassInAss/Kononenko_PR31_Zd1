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
        public static ObservableCollection<ServicePhoto> services_photos { get; set; } = Session.Context.ServicePhoto.Local;

        public static bool SaveChanges(string name, string cost,
            string duration, string description,
            string discount, string image_path,
            string image1, string image2, string image3)
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
                        DurationInSeconds = Convert.ToInt32(duration),
                        Description = description,
                        Discount = Convert.ToDouble(discount),
                        MainImagePath = image_path
                    });
                    if (image1 != null && image1 != String.Empty)
                    {
                        services_photos.Add(new ServicePhoto { ServiceID = services.Where(x => x.Title == name).Select(x => x.ID).First(), PhotoPath = image1 });
                    }
                    if (image2 != null && image2 != String.Empty)
                    {
                        services_photos.Add(new ServicePhoto { ServiceID = services.Where(x => x.Title == name).Select(x => x.ID).First(), PhotoPath = image2 });
                    }
                    if (image3 != null && image3 != String.Empty)
                    {
                        services_photos.Add(new ServicePhoto { ServiceID = services.Where(x => x.Title == name).Select(x => x.ID).First(), PhotoPath = image3 });
                    }
                    Session.Context.SaveChanges();
                    return true;
                }
                else
                {
                    var tochange = services.Where(x => x.Title == name).Select(x => x).FirstOrDefault();
                    tochange.Title = name;
                    tochange.Cost = decimal.Parse(cost);
                    tochange.DurationInSeconds = Convert.ToInt32(duration);
                    tochange.Description = description;
                    tochange.Discount = Convert.ToDouble(discount);
                    tochange.MainImagePath = image_path;
                    var enable_photos = services_photos.Where(x => x.ServiceID == tochange.ID).ToList();

                    if (image1 != String.Empty || image2 != String.Empty || image3 != String.Empty)
                    {
                        if (enable_photos.Count == 1)
                        {
                            if (image1 != String.Empty)
                            {
                                enable_photos[0].PhotoPath = image1;
                                if (image2 != String.Empty)
                                    services_photos.Add(new ServicePhoto { ServiceID = services.Where(x => x.Title == name).Select(x => x.ID).First(), PhotoPath = image2 });
                                if (image3 != String.Empty)
                                    services_photos.Add(new ServicePhoto { ServiceID = services.Where(x => x.Title == name).Select(x => x.ID).First(), PhotoPath = image3 });
                            }
                            else if (image2 != String.Empty)
                            {
                                enable_photos[0].PhotoPath = image2;
                                if (image1 != String.Empty)
                                    services_photos.Add(new ServicePhoto { ServiceID = services.Where(x => x.Title == name).Select(x => x.ID).First(), PhotoPath = image1 });
                                if (image3 != String.Empty)
                                    services_photos.Add(new ServicePhoto { ServiceID = services.Where(x => x.Title == name).Select(x => x.ID).First(), PhotoPath = image3 });
                            }
                            else if (image3 != String.Empty)
                            {
                                enable_photos[0].PhotoPath = image3;
                                if (image1 != String.Empty)
                                    services_photos.Add(new ServicePhoto { ServiceID = services.Where(x => x.Title == name).Select(x => x.ID).First(), PhotoPath = image1 });
                                if (image2 != String.Empty)
                                    services_photos.Add(new ServicePhoto { ServiceID = services.Where(x => x.Title == name).Select(x => x.ID).First(), PhotoPath = image2 });
                            }
                        }
                        else if (enable_photos.Count == 2)
                        {
                            if (image1 != String.Empty && image2 != String.Empty)
                            {
                                enable_photos[0].PhotoPath = image1;
                                enable_photos[1].PhotoPath = image2;
                                if (image3 != String.Empty)
                                    services_photos.Add(new ServicePhoto { ServiceID = services.Where(x => x.Title == name).Select(x => x.ID).First(), PhotoPath = image3 });
                            }
                            else if (image1 != String.Empty && image3 != String.Empty)
                            {
                                enable_photos[0].PhotoPath = image1;
                                enable_photos[1].PhotoPath = image3;
                                if (image2 != String.Empty)
                                    services_photos.Add(new ServicePhoto { ServiceID = services.Where(x => x.Title == name).Select(x => x.ID).First(), PhotoPath = image2 });
                            }
                            else if (image2 != String.Empty && image3 != String.Empty)
                            {
                                enable_photos[0].PhotoPath = image2;
                                enable_photos[1].PhotoPath = image3;
                                if (image1 != String.Empty)
                                    services_photos.Add(new ServicePhoto { ServiceID = services.Where(x => x.Title == name).Select(x => x.ID).First(), PhotoPath = image1 });
                            }
                        }
                        else if (enable_photos.Count == 3)
                        {
                            if (image1 != String.Empty)
                                enable_photos[0].PhotoPath = image1;
                            if (image2 != String.Empty)
                                enable_photos[1].PhotoPath = image2;
                            if (image3 != String.Empty)
                                enable_photos[2].PhotoPath = image3;
                        }
                        else
                        {
                            if (image1 != String.Empty)
                                services_photos.Add(new ServicePhoto { ServiceID = services.Where(x => x.Title == name).Select(x => x.ID).First(), PhotoPath = image1 });
                            if (image2 != String.Empty)
                                services_photos.Add(new ServicePhoto { ServiceID = services.Where(x => x.Title == name).Select(x => x.ID).First(), PhotoPath = image2 });
                            if (image3 != String.Empty)
                                services_photos.Add(new ServicePhoto { ServiceID = services.Where(x => x.Title == name).Select(x => x.ID).First(), PhotoPath = image3 });
                        }
                    }
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
                var photos_serv = services_photos.Where(x => x.ServiceID == service.ID).ToList();
                foreach (var item in photos_serv)
                {
                    services_photos.Remove(item);
                }
                Session.Context.SaveChanges();
            }
        }
    }
}
