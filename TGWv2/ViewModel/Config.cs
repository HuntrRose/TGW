using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HexLib;

namespace TGWv2.ViewModel
{
    public class Config : INotifyPropertyChanged
    {
        private int _boardHeight = 10;
        private int _boardWidth = 10;
        private int _numberOfInfantry = 1;
        private int _numberOfArmoredCar = 1;
        private int _numberOfArtillery=1;
        private bool _useInfantry = false;
        private bool _useArmoredCar = true;
        private bool _useArtillery = false;
        private int _tileSize = 30;
        private static Config _instance;
        

        public static RoutedCommand OptionsCommand = new RoutedCommand("Show Options", typeof(Config), new InputGestureCollection(new List<InputGesture> { new KeyGesture(Key.O, ModifierKeys.Control) }));

        private Config()
        {

        }

        public static Config Instance
        {
           get
           {
                if (_instance == null)
                {
                    _instance = new Config();
                }
                return _instance;
           }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        public int BoardHeight
        {
            get { return _boardHeight; }
            set
            {
                _boardHeight = value;
                OnPropertyChanged("BoardHeight");
            }
        } 
        public int BoardWidth
        {
            get { return _boardWidth; }
            set
            {
                _boardWidth = value;
                OnPropertyChanged("BoardWidth");
            }
        }
        public bool UseInfantry
        {
            get { return _useInfantry; }
            set
            {
                _useInfantry = value;
                OnPropertyChanged("UseInfantry");
            }
        }
        public bool UseArmoredCar
        {
            get { return _useArmoredCar; }
            set
            {
                _useArmoredCar = value;
                OnPropertyChanged("UseArmoredCar");
            }
        }
        public bool UseArtillery
        {
            get { return _useArtillery; }
            set
            {
                _useArtillery = value;
                OnPropertyChanged("UseArtillery");
            }
        }
        public int TileSize
        {
            get { return _tileSize; }
            set
            {
                _tileSize = value;
                OnPropertyChanged("TileSize");
            }
        }

        public int NumberOfInfantry
        {
            get { return _numberOfInfantry; }
            set
            {
                _numberOfInfantry = value;
                OnPropertyChanged("NumberOfInfantry");
            }
        }
        public int NumberOfArmoredCar
        {
            get { return _numberOfArmoredCar; }
            set
            {
                _numberOfArmoredCar = value;
                OnPropertyChanged("NumberOfArmoredCar");
            }
        }
        public int NumberOfArtillery
        {
            get { return _numberOfArtillery; }
            set
            {
                _numberOfArtillery = value;
                OnPropertyChanged("NumberOfArtillery");
            }
        }
    }
}
