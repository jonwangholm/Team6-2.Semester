using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budweg.MVVM.ViewModels.Persistence
{
    public class RepositoryManager
    {
        public static EmployeeRepository EmployeeRepository { get; set; }   
        public static MessageRepository MessageRepository { get; set; }
        public static ReportRepository ReportRepository { get; set; }

    }
}
