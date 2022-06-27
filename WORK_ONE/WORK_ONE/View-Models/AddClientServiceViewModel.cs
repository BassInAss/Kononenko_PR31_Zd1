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
    public static class AddClientServiceViewModel
    {
        public static ObservableCollection<ClientService> clientServices { get; set; } = Session.Context.ClientService.Local;
        public static ObservableCollection<Client> clients { get; set; } = Session.Context.Client.Local;

        public static bool AddClient(Service service, string fio, string time, DateTime? date)
        {
            int idService = service.ID;
            int idClient = 0;
            if (fio == String.Empty || fio == null)
            {
                MessageBox.Show("Выберите клиента!");
                return false;
            }
            else if (time == String.Empty || time == null)
            {
                MessageBox.Show("Введите время записи!");
                return false;
            }
            else
            {
                idClient = (clients.Where(x => x.FirstName == fio.Split(' ')[0]).Select(x => x.ID).First());
                //17.07.2015 17:04:43
                if (date == null)
                    date = DateTime.Now.Date;
                date = date.Value.Add(TimeSpan.Parse(time));
                clientServices.Add(new ClientService { ServiceID = idService, ClientID = idClient, StartTime = (DateTime)date });
                Session.Context.SaveChanges();
            }
            return true;
        }
    }
}
