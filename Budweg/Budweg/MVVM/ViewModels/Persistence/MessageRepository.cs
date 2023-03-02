using Budweg.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budweg.MVVM.ViewModels.Persistence
{
    public class MessageRepository : Repository
    {
      
        List<Message> messages = new List<Message>();

        public override void Load()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM MESSAGE", con);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int MessageId = int.Parse(dr["MessageId"].ToString());
                        string Content = dr["Content"].ToString();
                        DateTime SendTime = DateTime.Parse(dr["SendTime"].ToString());
                        int ReportId = int.Parse(dr["ReportId"].ToString());

                        Message message = new Message(Content, SendTime);
                        message.MessageId = MessageId;
                        messages.Add(message);
                        Report report = ReportRepository.Instance.Retrieve(ReportId);
                        report.Chat.Add(message);
                    }
                }
            }
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }
    }
}
