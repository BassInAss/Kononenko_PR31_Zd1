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
    public class HeirClass
    {
        public ClientService clientService { get; set; }
        public string time { get; set; }
        public string shortdate { get; set; }
        public string timetostart { get; set; }
    }
    public class ServiceViewModel
    {
        public static ObservableCollection<Service> services { get; set; } = Session.Context.Service.Local;
        public static ObservableCollection<ClientService> clientServices { get; set; } = Session.Context.ClientService.Local;
        public static List<Service> LoadList()
        {
            string path = "/Resourses/Images/ForDB/";
            foreach (var item in services)
            {
                if (!item.MainImagePath.Contains(path) && !item.MainImagePath.Contains("/"))
                    item.MainImagePath = path + item.MainImagePath;
                item.Cost = Math.Round(item.Cost);
                if (item.DurationInSeconds > 60)
                    item.DurationInSeconds /= 60;
                if (item.Discount < 1)
                    item.Discount *= 100;
            }
            return services.ToList();
        }
        public static List<HeirClass> LoadClientServiceList()
        {
            List<HeirClass> toload = new List<HeirClass>();
            foreach (var item in clientServices)
            {
                toload.Add(new HeirClass { clientService = item, time = item.StartTime.TimeOfDay.ToString(@"hh\:mm"), shortdate = item.StartTime.ToString("d"), timetostart = (DateTime.Now.TimeOfDay - item.StartTime.TimeOfDay).ToString("%h' час(ов) '%m' минут(а)'") });
            }
            return toload;
        }
    }
}
