using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheMovies.Model;

namespace TheMovies.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public string EnterTitle { get; set; }
        public int EnterDuration { get; set; }
        public string EnterGenre { get; set; }

   



        public ObservableCollection<Film> filmList { get; set; }

        public MainViewModel()
        {
            filmList = new ObservableCollection<Film>
            {
                new Film("Good Film", 30, "Action"),
                new Film("Good Film2", 30, "Action")
            };

        }

        public ICommand NewCmd { get; set; } = new NewCommand();

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

    }
}
