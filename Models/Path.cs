using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Synonymous.Models
{
    public class Path
    {
        public Path(Node keyword, Node synonym)
        {
            Keyword = keyword;
            Synonym = synonym;
        }

        public Node Keyword { get; set; }
        public Node Synonym { get; set; }
    }
}
