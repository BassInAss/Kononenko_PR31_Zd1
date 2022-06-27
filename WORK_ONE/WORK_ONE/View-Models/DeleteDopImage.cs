using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WORK_ONE.Models;

namespace WORK_ONE.View_Models
{
    public static class DeleteDopImage
    {
        public static ObservableCollection<ServicePhoto> services_photos { get; set; } = Session.Context.ServicePhoto.Local;

        public static bool Delete(string path, Service service)
        {
            var item = services_photos.Where(x => x.ServiceID == service.ID).Where(x => x.PhotoPath == path).FirstOrDefault();
            if (item != null)
                services_photos.Remove(item);
            else
                return false;
            Session.Context.SaveChanges();
            return true;
        }
    }
}
