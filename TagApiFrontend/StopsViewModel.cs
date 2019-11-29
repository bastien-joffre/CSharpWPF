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

        private string _lat;
        public string Lat
        {
            get { return _lat; }
            set
            {
                if (_lat != value)
                {
                    _lat = value;
                    RaisePropertyChanged(nameof(Lat));
                }
            }
        }

        private string _lon;
        public string Lon
        {
            get { return _lon; }
            set
            {
                if (_lon != value)
                {
                    _lon = value;
                    RaisePropertyChanged(nameof(Lon));
                }
            }
        }

        public string Coordinates
        {
            get
            {
                return Lat + ", " + Lon;
            }
            set { }
        }

        private List<string> _location;
        public List<string> Location
        {
            get { return _location; }
            set
            {
                _location = value;
                RaisePropertyChanged(nameof(Location));
            }
        }

        public StopsViewModel()
        {
            _api = new UtilApi();
            Radius = 500;
            Lat = "45.185603";
            Lon = "5.727718";
            searchStops();
            SearchButton = new RelayCommand(this.searchStops);
        }

        public void searchStops()
        {
            StopList = getInfos(Radius);

            List<string> loc = new List<string>();

            foreach (KeyValuePair<string, List<Stop>> stop in StopList)
            {
                foreach (Stop s in stop.Value)
                {
                    string strLat = s.lat;
                    string strLon = s.lon;
                    loc.Add(strLat + "," + strLon);
                }
            }
            this.Location = loc;
        }

        public Dictionary<string, List<Stop>> getInfos(int dist)
        {
            return _api.getStopList(dist, Lon, Lat);
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
