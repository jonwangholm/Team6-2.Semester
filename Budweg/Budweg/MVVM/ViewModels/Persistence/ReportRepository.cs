using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budweg.MVVM.Models;

namespace Budweg.MVVM.ViewModels.Persistence
{
    public class ReportRepository : Repository
    {
        #region Singleton Pattern
        private static ReportRepository _instance;

        public static ReportRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ReportRepository();
                    return _instance;
                }
                return _instance;
            }
        }
        #endregion

        private List<Report> reports = new List<Report>();

        public override void Load()
        {
            throw new NotImplementedException();
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }

        public Report Retrieve(int Id)
        {
            foreach (Report report in reports)
            {
                if (Id == report.ReportId)
                {
                    return report;
                }
            }
            return null;
        }
    }
}
