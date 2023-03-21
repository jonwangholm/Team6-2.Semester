using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Budweg.MVVM.Models;

namespace Budweg.MVVM.ViewModels.Persistence
{
    public class ReportRepository : Repository
    {
        private List<Report> reports = new List<Report>();

        public override void Load()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM REPORT", con);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int ReportId = int.Parse(dr["ReportId"].ToString());
                        string Subject = dr["Subject"].ToString();
                        string Title = dr["Title"].ToString();
                        bool IsAnon = bool.Parse(dr["IsAnonymous"].ToString());

                        Employee Sender = RepositoryManager.EmployeeRepository.Retrieve(dr["Email"].ToString());

                        Report report = new Report(Subject, Title, IsAnon, Sender);

                        report.ReportId = ReportId;
                        reports.Add(report);
                    }
                }
            }
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }

        public Report Retrieve(int Id)
        {
            foreach (Report report in reports)
                if (Id == report.ReportId)
                    return report;

            return null;
        }

        public List<Report> RetrieveAll()
        {
            return new(reports);
        }

        public List<Report> RetrieveReports(string email)
        {
            throw new NotImplementedException();
        }

        public Report Create(Report report)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO REPORT(Subject, Title, IsAnonymous, Email)" +
                    "VALUES(@Subject, @Title, @IsAnonymous, @Email)" +
                    "SELECT @@IDENTITY", con);

                cmd.Parameters.Add("@Subject", SqlDbType.NVarChar).Value = report.Subject;
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = report.Title;
                cmd.Parameters.Add("@IsAnonymous", SqlDbType.Bit).Value = report.IsAnon;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = report.Sender;

                report.ReportId = Convert.ToInt32(cmd.ExecuteScalar());

                reports.Add(report);

                return report;
            }
        }
    }
}
