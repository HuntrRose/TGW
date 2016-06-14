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
using TGWv2.ViewModel;

namespace TGWv2
{
    /// <summary>
    /// Interaction logic for InterfaceOverlay.xaml
    /// </summary>
    public partial class InterfaceOverlay : UserControl
    {
        public InterfaceOverlay()
        {
            InitializeComponent();
        }

        private void poly_MouseEnter(object sender, MouseEventArgs e)
        {
            /*Overlay overlay = DataContext as Overlay;
            if(overlay.Unit != null)
            {
                if (overlay.State != OverlayStates.selected)
                {
                    overlay.State = OverlayStates.possible;
                }
            }  */          
        }

        private void poly_MouseLeave(object sender, MouseEventArgs e)
        {
            /*Overlay overlay = DataContext as Overlay;
            if (overlay.State == OverlayStates.possible)
            {
                overlay.State = OverlayStates.normal;
            }*/
        }

        private void poly_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Overlay overlay = DataContext as Overlay;
            ViewModel.ViewModel.FieldClicked(overlay.MapTile);
        }
    }
}
