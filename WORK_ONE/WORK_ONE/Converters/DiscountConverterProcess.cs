using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WORK_ONE.Converters
{
    public class DiscountConverterProcess : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal price = (decimal)value[1];
            double discount = (double)value[0];

            if ((double)value[0] != 0)
            {
                if ((double)value[0] > 0)
                {
                    return $"Цена со скидкой: {(double)price - ((double)price * (double)discount / 100)}";
                }
            }
            return $"{(decimal)value[1]}";
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
