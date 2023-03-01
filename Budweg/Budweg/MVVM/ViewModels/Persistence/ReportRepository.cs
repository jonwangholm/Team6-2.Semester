using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        public Report Create(Report report) 
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO REPORT(Subject, Title, IsAnon, Email)" +
                    "VALUES(@Subject, @Title, @IsAnon, @Email)" + 
                    "SELECT @@IDENTITY", con);
                cmd.Parameters.Add("@Subject", SqlDbType.NVarChar).Value = report.Subject;
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = report.Title;
                cmd.Parameters.Add("@IsAnon", SqlDbType.Bit).Value = report.IsAnon;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = report.Sender;
                report.ReportId = Convert.ToInt32(cmd.ExecuteScalar());
                
                reports.Add(report);
                return report;
            }
        }
    }
}
