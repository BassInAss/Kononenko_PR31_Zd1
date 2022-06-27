using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace WORK_ONE.Converters
{
    public class TodayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime starttime = (DateTime)value;
            if ((DateTime)starttime.Date == DateTime.Today)
            {
                if (starttime.TimeOfDay.TotalMinutes < DateTime.Now.TimeOfDay.TotalMinutes)
                    return Visibility.Collapsed;
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Visibility)value == Visibility.Visible;
        }
    }
}
