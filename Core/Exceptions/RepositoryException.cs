using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions
{
    public class RepositoryException : Exception
    {
        public RepositoryException(string message, Exception innerException)
            : base(message, innerException)
        { }

        public override string Message
        {
            get
            {
                var msg = InnerException != null ? ", InnerException Message:" + InnerException.Message : "";

                return $"Message:{base.Message}{msg}";
            }
        }
    }
}
