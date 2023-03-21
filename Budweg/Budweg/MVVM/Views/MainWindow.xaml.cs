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
using Budweg.MVVM.ViewModels.Persistence;
using Budweg.MVVM.Views;

namespace Budweg
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///
    
    public partial class MainWindow : Window
    {
        private CreateReportViewVM CreateView = new CreateReportViewVM();

        ViewReportViewVM ViewReport = new ViewReportViewVM();


        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainVM();
        }

        private void indtastBtn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = CreateView;

        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            DataContext = ViewReport;

        }
    }
}