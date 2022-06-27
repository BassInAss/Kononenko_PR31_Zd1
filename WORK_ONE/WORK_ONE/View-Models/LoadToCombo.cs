using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WORK_ONE.View_Models
{
    public static class LoadToCombo
    {
        public static ObservableCollection<string> DiscountComboLoad()
        {
            ObservableCollection<string> list = new ObservableCollection<string>();
            list.Add("");
            list.Add("от 0% до 5%");
            list.Add("от 5% до 15%");
            list.Add("от 15% до 30%");
            list.Add("от 30% до 70%");
            list.Add("от 70% до 100%");
            return list;
        }
    }
}
