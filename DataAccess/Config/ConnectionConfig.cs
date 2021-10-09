using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Config
{
    public class ConnectionConfig
    {
        public string ConnectionString { get; } = @"Server=(localdb)\MSSQLLocalDB;Database=MovieAppDb;Trusted_Connection=True;";
    }
}
