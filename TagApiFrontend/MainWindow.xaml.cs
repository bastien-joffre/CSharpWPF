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
using TagApiLibrary;

namespace TagApiFrontend
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UtilApi _api;

        public MainWindow()
        {
            InitializeComponent();
            _api = new UtilApi();
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, List<Stop>> stops = _api.getListLigne(500);

            string result = "";
            foreach (KeyValuePair<string, List<Stop>> stopGroup in stops)
            {
                result += stopGroup.Key;
                foreach (Stop stop in stopGroup.Value)
                {
                    result += stop;
                }
            }
            Content.Text = result;
        }
    }
}
