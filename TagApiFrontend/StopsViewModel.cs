using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TagApiLibrary;

namespace TagApiFrontend
{
    public class StopsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        UtilApi _api;
        string _stopList;

        public string StopList
        {
            get { return _stopList; }
            set
            {
                if (_stopList != value)
                {
                    _stopList = value;
                    this.RaisePropertyChanged(nameof(StopList));
                }
            }
        }

        public StopsViewModel()
        {
            _api = new UtilApi();
            StopList = getInfos(500);
        }

        public string getInfos(int dist)
        {
            _api = new UtilApi();

            Dictionary<string, List<Stop>> stops = _api.getStopList(dist);

            string result = "";
            foreach (KeyValuePair<string, List<Stop>> stopGroup in stops)
            {
                result += stopGroup.Key;
                foreach (Stop stop in stopGroup.Value)
                {
                    result += stop;
                }
            }
            return result;
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
