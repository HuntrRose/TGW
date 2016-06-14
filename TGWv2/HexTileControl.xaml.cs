using HexLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TGWv2
{
    /// <summary>
    /// Interaction logic for HexTileControl.xaml
    /// </summary>
    public partial class HexTileControl : UserControl
    {
        public HexTileControl()
        {
            InitializeComponent();
        }

        private void Polygon_MouseEnter(object sender, MouseEventArgs e)
        {
            
        }

        private void poly_MouseLeave(object sender, MouseEventArgs e)
        {
            poly.Stroke = new SolidColorBrush(Colors.Black);

        }
    }
}
