using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budweg.MVVM.ViewModels.Persistence
{
    public static class RepositoryManager
    {
        public static EmployeeRepository EmployeeRepository { get; set; } = new();
        public static MessageRepository MessageRepository { get; set; } = new();
        public static ReportRepository ReportRepository { get; set; } = new();
    }
}
