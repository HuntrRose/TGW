using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using HexLib;

namespace TGWv2.ViewModel
{
    public class TerrainTypeToImageBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            if (value == null)
                return null;

            TerrainTypes val = (TerrainTypes)value;
           
                if (val == TerrainTypes.Forrest)
                    return new ImageBrush() { ImageSource = new BitmapImage(new Uri("img\\terforrest.png", UriKind.Relative)) };
                if (val == TerrainTypes.Swamp)
                    return new ImageBrush() { ImageSource = new BitmapImage(new Uri("img\\terswamp.png", UriKind.Relative)) };
                if (val == TerrainTypes.Mountain)
                    return new ImageBrush() { ImageSource = new BitmapImage(new Uri("img\\termountain.png", UriKind.Relative)) };
                else
                    return new ImageBrush() { ImageSource = new BitmapImage(new Uri("img\\terplain.png", UriKind.Relative)) };
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
