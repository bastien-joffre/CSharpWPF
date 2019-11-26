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

namespace TagApiFrontend
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StopsViewModel _stopsVM;

        public MainWindow()
        {
            InitializeComponent();
            _stopsVM = new StopsViewModel();
            this.DataContext = _stopsVM;
        }

        //private void Btn2_Click(object sender, RoutedEventArgs e)
        //{
        //    Content.Text = _stopsVM.getInfos(500);
        //}
    }
}
