using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budweg.MVVM.ViewModels.Persistence
{
    public abstract class Repository
    {
        protected string ConnectionString = "Server=10.56.8.36; Database=P1_DB_2023_06; User Id=PROJECT_USER_06; Password=OPENDB_06; TrustServerCertificate=true";

        public abstract void Load();
        public abstract void Save();
    }
}
