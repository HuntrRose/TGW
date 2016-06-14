using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace TGWv2.ViewModel
{
    class UnitCenterToMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || !(value is Point))
                return null;

            Point point = (Point)value;
            int x = (int)point.X;
            int y = (int)point.Y;
            //return ("0,0,0,0");
            return string.Format("{0},{1},0,0", (x-30).ToString(), (y-30).ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
