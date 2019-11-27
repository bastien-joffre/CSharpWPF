using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TagApiLibrary;

namespace TagApiFrontend
{
    public class StopsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        UtilApi _api;
        Dictionary<string, List<Stop>> _stopList;
        int _radius;
        ICommand _searchButton;

        public ICommand SearchButton
        {
            get
            {
                return _searchButton;
            }
            set
            {
                _searchButton = value;
            }
        }

        public Dictionary<string, List<Stop>> StopList
        {
            get { return _stopList; }
            set
            {
                if (_stopList != value)
                {
                    _stopList = value;
                    RaisePropertyChanged(nameof(StopList));
                }
            }
        }

        public int Radius {
            get { return _radius;  }
            set
            {
                if (_radius != value)
                {
                    _radius = value;
                    RaisePropertyChanged(nameof(Radius));
                }
            }
        }

        public StopsViewModel()
        {
            _api = new UtilApi();
            Radius = 500;
            searchStops();
            SearchButton = new RelayCommand(this.searchStops);
        }

        public void searchStops()
        {
            StopList = getInfos(Radius);
        }

        public Dictionary<string, List<Stop>> getInfos(int dist)
        {
            return _api.getStopList(dist);
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
