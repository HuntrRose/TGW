using HexLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using UnitLib;

namespace TGWv2.ViewModel
{
    public class Overlay : INotifyPropertyChanged
    {
        private HexField _mapTile;
        private Unit _unit;
        private Point _center;
        private int _radius;
        private PointCollection _points = new PointCollection();
        private OverlayStates _state;


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            var handler = PropertyChanged;
            if (handler != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        private void CalculatePoints()
        {
            
            _points.Clear();
            for (var i = 0; i <= 6; i++)
            {
                var angleDeg = 60 * i + 30;
                var angleRad = Math.PI / 180 * angleDeg;
                _points.Add(new Point(_center.X + _radius * Math.Cos(angleRad), _center.Y + _radius * Math.Sin(angleRad)));
            }
            OnPropertyChanged("Points");
        }

        public int Radius
        {
            get { return _radius; }
            set
            {
                _radius = value;
                CalculatePoints();
            }
        }

        public Point Center
        {
            get { return _center; }
            set
            {
                _center = value;
                CalculatePoints();
            }
        }
        public HexField MapTile
        {
            get { return _mapTile; }
            set
            {
                _mapTile = value;
                OnPropertyChanged("MapTile");
            }
        }

        public PointCollection Points
        {
            get { return _points; }
            set
            {
                _points = value;
                OnPropertyChanged("Points");
            }
        }

        public Unit Unit
        {
            get { return _unit; }
            set
            {
                _unit = value;
                OnPropertyChanged("Unit");
            }
        }

        public OverlayStates State
        {
            get { return _state; }
            set
            {
                _state = value;
                OnPropertyChanged("State");
            }
        }

    }



    public enum OverlayStates { normal, possible, selected };
}
