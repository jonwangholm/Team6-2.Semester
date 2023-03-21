using Budweg.MVVM.Models;
using Budweg.MVVM.ViewModels;
using Budweg.MVVM.ViewModels.Persistence;
using Budweg.MVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Budweg.MVVM.Commands
{
    public class CreateReportCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;

        }

        public void Execute(object? parameter)
        {
            if (parameter is MainVM MVM)
            {
                CreateReportViewVM CRVM = new CreateReportViewVM();

                Report report = new(CRVM.EnterTitle, CRVM.EnterChat, CRVM.IsAnon, new Employee("A", "A@a.dk", false));


                MVM.reportsList.Add(report);

                RepositoryManager.ReportRepository.Create(report);
            }
        }
    }
}
