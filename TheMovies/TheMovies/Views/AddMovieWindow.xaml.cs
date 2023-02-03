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
using System.Windows.Shapes;
using TheMovies.ViewModel;

namespace TheMovies.View
{
    /// <summary>
    /// Interaction logic for AddMovieWindow.xaml
    /// </summary>
    /// 

    public partial class AddMovieWindow : Window
    {
        MainViewModel mvm = new MainViewModel();


        public AddMovieWindow()
        {
            InitializeComponent();

            DataContext = mvm;

            
        }

        private void new_Clicked(object sender, RoutedEventArgs e)
        {

            //  mvm.filmList.Add(new Film(titleLbl.Text, int.Parse(durationLbl.Text), genreLbl.Text));

            mvm.CreateNewMovie(mvm, titleLbl.Text, int.Parse(durationLbl.Text), genreLbl.Text);
            this.DialogResult = true;


        }

    
    }
}
