using System.Collections.ObjectModel;
using System.ComponentModel;

using Budweg.MVVM.Models;
using Budweg.MVVM.ViewModels.Domain;
using Budweg.MVVM.ViewModels.Persistence;

namespace Budweg.MVVM.ViewModels
{
    public class MainVM : INotifyPropertyChanged
    {
        private EmployeeVM activeEmployeeVM;



        public EmployeeVM ActiveEmployeeVM
        {
            get { return activeEmployeeVM; }

            set
            {
                activeEmployeeVM = value;
                OnPropertyChanged(nameof(ActiveEmployeeVM));
            }
        }

        private ObservableCollection<ReportVM> reportVMs;
        public ObservableCollection<ReportVM> ReportVMs
        {
            get { return reportVMs; }

            set
            {
                reportVMs = value;
                OnPropertyChanged(nameof(ReportVMs));
            }
        }

        private ReportVM? selectedReportVM;
        public ReportVM? SelectedReportVM
        {
            get { return selectedReportVM; }

            set
            {
                selectedReportVM = value;
                OnPropertyChanged(nameof(SelectedReportVM));
            }
        }

        #region Commands

        #endregion

        #region OnChanged events
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged is not null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }
        #endregion

        public MainVM ()
        {
            // This is placeholder code - this should eventually be replaced with some sort of login functionality
            EmployeeVM activeEmployee = new (RepositoryManager.EmployeeRepository.Retrieve("ole@hotmail.com"));

            ActiveEmployeeVM = activeEmployee;

            ReportVMs = new();

            foreach (Report report in RepositoryManager.ReportRepository.RetrieveAll())
                ReportVMs.Add(new ReportVM(report));

            //foreach (Report report in RepositoryManager.ReportRepository.RetrieveReports(ActiveEmployeeVM.Email))
            //    ReportVMs.Add(new (report));
        }
    }
}
