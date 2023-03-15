using Budweg.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budweg.MVVM.Views;

namespace Budweg.MVVM.ViewModels.Domain
{
    public class ReportVM
    {
        private Report source;

        public string Subject { get; set; }
        public string Title { get; set; }
        public bool IsAnon { get; set; }
        public EmployeeVM Sender { get; set; }
        public ObservableCollection<MessageVM> Chat { get; set; }
        public int ReportId { get; }

        public ReportVM(Report source)
        {
            this.source = source;

            Subject = source.Subject;
            Title = source.Title;
            IsAnon = source.IsAnon;

            Sender = new(source.Sender);

            Chat = new();

            foreach (Message message in source.Chat)
                Chat.Add(new MessageVM(message));

            ReportId = source.ReportId;
        }

        public void Delete()
        {
            throw new NotImplementedException();
            // RepositoryManager.ReportRepository.Delete(source);
        }
    }
}
