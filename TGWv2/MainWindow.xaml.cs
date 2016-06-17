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
using System.Windows.Shapes;
using TGWv2.ViewModel;
using UnitLib;

namespace TGWv2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Config _config = Config.Instance;
        public static Grid GameField;
        public MainWindow()
        {
            InitializeComponent();
            GameField = new Grid();
            GameField.HorizontalAlignment = HorizontalAlignment.Left;
            GameField.VerticalAlignment = VerticalAlignment.Top;
            //GameField.Background;
            GameScrollView.Content = GameField;
            
        }

        public static RoutedCommand NewGameCommand = new RoutedCommand("New Game", typeof(NewGame),new InputGestureCollection(new List<InputGesture> { new KeyGesture(Key.N, ModifierKeys.Control) }));

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (e.Command == MainWindow.NewGameCommand)
                e.CanExecute = true;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if(e.Command == MainWindow.NewGameCommand)
            {
                var dialog = new NewGame();
                var result = dialog.ShowDialog();
                if (result ==  true)
                {
                    SetupGame();
                    ViewModel.ViewModel.StartGame();
                }
            }
        }

        private void SetupGame()
        {
            GameField.Children.Clear();
            ViewModel.ViewModel.CreateBoard();
            List<List<HexField>> board = ViewModel.ViewModel.Board.HexGrid;
            foreach(List<HexField> row in board)
            {
                foreach(HexField field in row)
                {
                    if(!(field == null))
                    {
                        HexTileControl tile = new HexTileControl();
                        tile.DataContext = field;
                        GameField.Children.Add(tile);
                    }
                }
            }
            ViewModel.ViewModel.CreateUnits();
            /*List<Unit> p1Units = ViewModel.ViewModel.Units;
            foreach (Unit unit in p1Units)
            {
                UnitControl unitControl = new UnitControl();
                unitControl.DataContext = unit;
                GameField.Children.Add(unitControl);
            }*/
            List<Player> players = ViewModel.ViewModel.Players;
            foreach(Player player in players)
            {
                foreach(Unit unit in player.Units)
                {
                    UnitControl unitControl = new UnitControl();
                    unitControl.DataContext = unit;
                    GameField.Children.Add(unitControl);
                }
            }
            foreach(List<Overlay> overlayTiles in ViewModel.ViewModel.OverlayTiles)
            {
                foreach(Overlay overlay in overlayTiles)
                {
                    if (overlay == null)
                        continue;
                    else
                    {
                        InterfaceOverlay interfaceOverlay = new InterfaceOverlay();
                        interfaceOverlay.DataContext = overlay;
                        GameField.Children.Add(interfaceOverlay);
                    }
                }
            }
        }

        private void ExitOption_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void endTurnButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.ViewModel.endTurn();
        }

        public static void RemoveUnit(UnitControl uc)
        {
            uc.Visibility = Visibility.Hidden;
            GameField.Children.Remove(uc);
            uc.Content = null;
            uc.DataContext = null;
            uc.Opacity = 1;
            uc = null;
        }
    }
}
