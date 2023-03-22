using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budweg.MVVM.Models;
using Budweg.MVVM.ViewModels.Domain;
using Budweg.MVVM.ViewModels.Persistence;

namespace Budweg.MVVM.ViewModels
{
    public class CreateReportViewVM
    {
        public string Subject { get; set; }
        public string Title { get; set; }
        public bool IsAnon { get; set; }
        
        public ReportVM NewCreated { get; set; }

        public CreateReportViewVM()
        {

           
        }

        public void CreateReportCmd()
        {
            Report report = new Report("HVOR ER ADIL OG OGUZ?", "HJEMME", false, new Employee("Ole", "ole@hotmail.com", false), new List<Message>());

            NewCreated = new(RepositoryManager.ReportRepository.Create(report));
             
        }
    }
}
