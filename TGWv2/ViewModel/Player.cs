using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitLib;

namespace TGWv2.ViewModel
{
    public class Player : INotifyPropertyChanged
    {
        private String _name = "Player";
        private List<Unit> _units = new List<Unit>();
        public Player(String name)
        {
            this._name = name;
        }

        public String Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public List<Unit> Units
        {
            get { return _units; }
            set
            {
                _units = value;
                OnPropertyChanged("Units");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            var handler = PropertyChanged;
            if (handler != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
