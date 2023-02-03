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
using TheMovies.View;
using TheMovies.ViewModel;
using TheMovies.Model;


namespace TheMovies
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        MainViewModel mvm = new MainViewModel();
        public MainWindow()
        {

            InitializeComponent();

            DataContext = mvm;
            FilmRepo filmRepo = new FilmRepo();
            filmRepo.ReadFilm();
        }

        private void createBtn_Clicked(object sender, RoutedEventArgs e)
        {
            AddMovieWindow amw = new AddMovieWindow();


            if (amw.ShowDialog() == true) ;

            mvm.filmList.Add(new Film(amw.titleLbl.Text, int.Parse(amw.durationLbl.Text), amw.genreLbl.Text));


        }
    }
}
