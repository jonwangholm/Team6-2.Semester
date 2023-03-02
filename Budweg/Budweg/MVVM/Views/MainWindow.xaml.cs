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
using Budweg.MVVM.ViewModels;

namespace Budweg
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void indtastBtn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ReportViewModel();
            SendReportButton.Visibility = Visibility.Visible;
            MenuControl.Visibility = Visibility.Visible;
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            SendReportButton.Visibility = Visibility.Hidden;
            MenuControl.Visibility = Visibility.Hidden;

        }
    }
}