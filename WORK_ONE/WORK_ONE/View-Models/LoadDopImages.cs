using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WORK_ONE.Models;

namespace WORK_ONE.View_Models
{
    public static class LoadDopImages
    {
        public static ObservableCollection<ServicePhoto> photos { get; set; } = Session.Context.ServicePhoto.Local;
        public static string[] Load(Service service)
        {
            var servicephotos = photos.Where(x => x.ServiceID == service.ID).Select(x => x.PhotoPath).ToArray();
            return servicephotos;
        }
    }
}
