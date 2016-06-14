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
using System.Windows.Shapes;
using TGWv2.ViewModel;


namespace TGWv2
{
    /// <summary>
    /// Interaction logic for NewGame.xaml
    /// </summary>
    public partial class NewGame : Window
    {
        private Config config = Config.Instance;

        public NewGame()
        {
            InitializeComponent();
            //DialogResult = false;
            DataContext = config;
            InitializeComponent();
            for (int x = 10; x <= 60; x += 10)
            {
                boardHeightBox.Items.Add(x);
                boardWidthBox.Items.Add(x);
            }
            boardHeightBox.SelectedIndex = 0;
            boardWidthBox.SelectedIndex = 0;
            for (int x = 1; x <= 10; x++)
            {
                numberOfInfantryBox.Items.Add(x);
                numberOfArmoredCar.Items.Add(x);
                numberOfArtillery.Items.Add(x);
            }
            numberOfInfantryBox.SelectedIndex = 0;
            numberOfArmoredCar.SelectedIndex = 0;
            numberOfArtillery.SelectedIndex = 0;
        }

        private void startGameButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
