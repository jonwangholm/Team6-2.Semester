using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheMovies.Model;

namespace TheMovies.ViewModel
{
    class NewCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is MainViewModel mvm)
            {
                mvm.filmList.Add(new Film(mvm.EnterTitle, mvm.EnterDuration, mvm.EnterGenre));
            }
        }
    }
}
