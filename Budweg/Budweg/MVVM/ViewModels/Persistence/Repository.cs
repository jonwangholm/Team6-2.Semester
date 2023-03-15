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
        protected string ConnectionString = ConfigurationManager.ConnectionStrings["DatabaseServerInstance"].ConnectionString;

        public abstract void Load();
        public abstract void Save();
    }
}
