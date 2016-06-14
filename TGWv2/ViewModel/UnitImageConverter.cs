using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using UnitLib;

namespace TGWv2.ViewModel
{
    class UnitImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is InfantryUnit)
            {
                throw new NotImplementedException();
            }
            else if (value is ArmoredCarUnit)
            {
                string image = ".\\img\\unitACGreen.png";
                return image;
            }
            //else if (value is ArtilleryUnit)
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
