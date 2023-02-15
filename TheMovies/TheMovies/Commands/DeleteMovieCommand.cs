using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TheMovies.MVVM.Model;
using TheMovies.MVVM.ViewModel.Persistence;
using TheMovies.MVVM.ViewModel;

namespace TheMovies.Commands
{
    public class DeleteMovieCommand : ICommand
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
                FilmRepo.Instance.Delete(mvm.S1);
                mvm.FilmList.Remove(mvm.S1);
                mvm.S1 = null;
            }
        }
    }
}
