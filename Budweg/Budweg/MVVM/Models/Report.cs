using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budweg.MVVM.Models
{
    public class Report
    {
        public string Subject { get; set; }
        public string Title { get; set; }
        public bool IsAnon { get; set; }
        public Employee Sender { get; set; }
        public List<Message> Chat { get; set; }
        public int ReportId { get; set; }

        public Report(string subject, string title, bool isAnon, Employee sender)
        {
            Subject = subject;
            Title = title;
            IsAnon = isAnon;
            Sender = sender;
        }

        public Report()
        {

        }

    }
}
