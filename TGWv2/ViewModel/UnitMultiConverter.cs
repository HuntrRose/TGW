using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using UnitLib;

namespace TGWv2.ViewModel
{
    class UnitMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            
            if ((bool)values[1])
            {
                if (values[0] is InfantryUnit)
                {
                    throw new NotImplementedException();
                }
                else if (values[0] is ArmoredCarUnit)
                {
                    /*string image = ".\\img\\unitACGreen.png";
                    return image;*/
                    return new BitmapImage(new Uri(".\\img\\unitACGreen.png", UriKind.RelativeOrAbsolute));
                }
                //else if (value is ArtilleryUnit)
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
