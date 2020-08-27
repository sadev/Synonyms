using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Synonymous.Utils
{
    public class SynonymException:Exception
    {
        protected SynonymException()
        {
        }

        public SynonymException(string message)
            : this(null, message)
        {
        }

        public SynonymException(string message, params object[] args)
            : this(null, message, args)
        {
        }

        public SynonymException(Exception innerException, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
        }
    }
}
