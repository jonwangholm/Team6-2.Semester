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

        public MessageRepository()
        {
            Load();
        }

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
                        int messageId = int.Parse(dr["MessageId"].ToString());
                        string content = dr["Content"].ToString();
                        DateTime sendTime = DateTime.Parse(dr["SendTime"].ToString());
                        int reportId = int.Parse(dr["ReportId"].ToString());

                        Message message = new Message(content, sendTime);
                        message.MessageId = messageId;
                        message.ReportId = reportId;

                        messages.Add(message);
                    }
                }
            }
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }

        public void Create()
        {
            throw new NotImplementedException();
        }

        public List<Message> RetrieveAll()
        {
            return new(messages);
        }
    }
}
