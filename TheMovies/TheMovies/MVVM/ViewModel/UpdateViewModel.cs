using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TheMovies.MVVM.ViewModel
{
    public class UpdateViewModel : INotifyPropertyChanged
    {
        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        private string _genre;
        public string Genre
        {
            get { return _genre; }
            set 
            { 
                _genre = value;
                OnPropertyChanged(nameof(Genre));
            }
        }
        private int _duration;

        public int Duration
        {
            get { return _duration; }
            set
            {
                _duration = value;
                OnPropertyChanged(nameof(Duration));
            }
        }

        private string _director;

        public string Director
        {
            get { return _director; }
            set
            {
                _director = value;
                OnPropertyChanged(nameof(Director));
            }
        }

        private DateTime _premiereDate;

        public DateTime PremiereDate
        {
            get { return _premiereDate; }
            set
            {
                _premiereDate = value;
                OnPropertyChanged(nameof(PremiereDate));
            }
        }






        #region OnChanged events
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
        #endregion
    }
}
