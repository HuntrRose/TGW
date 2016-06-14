using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using HexLib;
using System.Windows.Media;

namespace TGWv2.ViewModel
{
    class StateToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            if (value is TileState)
            {
                TileState val = (TileState)value;

                if (val == TileState.Selected)
                    return Colors.Red;
                else if (val == TileState.Potential)
                    return Colors.Yellow;
                else
                    return Colors.Black;
            }
            else if (value is OverlayStates)
            {
                OverlayStates val = (OverlayStates)value;

                if (val == OverlayStates.selected)
                    return (new SolidColorBrush(Colors.Red));
                else if (val == OverlayStates.possible)
                    return (new SolidColorBrush(Colors.Yellow));
                else
                    return (new SolidColorBrush(Colors.Transparent));
            }
            else
                return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
