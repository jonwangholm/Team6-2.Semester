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

        public ReportRepository()
        {
            Load();
        }

        public override void Load()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM REPORT", con);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    List<Message> retrievedMessages = RepositoryManager.MessageRepository.RetrieveAll();

                    while (dr.Read())
                    {
                        int reportId = int.Parse(dr["ReportId"].ToString());
                        string subject = dr["Subject"].ToString();
                        string title = dr["Title"].ToString();
                        bool isAnon = bool.Parse(dr["IsAnonymous"].ToString());

                        Employee sender = RepositoryManager.EmployeeRepository.Retrieve(dr["Email"].ToString());

                        List<Message> messages = new();

                        foreach (Message message in retrievedMessages)
                            if (message.ReportId == reportId)
                                messages.Add(message);

                        Report report = new Report(subject, title, isAnon, sender, messages);

                        report.ReportId = reportId;
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
