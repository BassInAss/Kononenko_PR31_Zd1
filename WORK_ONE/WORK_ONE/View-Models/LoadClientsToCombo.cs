using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WORK_ONE.Models;

namespace WORK_ONE.View_Models
{
    public class LoadClientsToCombo
    {
        public static ObservableCollection<Client> clients { get; set; } = Session.Context.Client.Local;
        public static ObservableCollection<string> ClientsComboLoad()
        {
            ObservableCollection<string> list = new ObservableCollection<string>();
            list.Add(String.Empty);
            foreach (var item in clients)
            {
                list.Add($"{item.FirstName} {item.LastName} {item.Patronymic}");
            }
            return list;
        }
    }
}
