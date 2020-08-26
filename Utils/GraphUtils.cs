using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Synonymous.Models;

namespace Synonymous.Utils
{
    public class GraphUtils
    {
        public static void GetSynonyms(Node keyword, List<Path> data, ref List<string> result)
        {
            keyword.Visited = true;
            List<Node> outgoing = new List<Node>();

            foreach (Path path in data) //O(n)
            {
                if (path.Synonym.Value.ToLower() == keyword.Value.ToLower() && !path.Synonym.Visited)
                {
                    outgoing.Add(path.Keyword);
                    result.Add(path.Keyword.Value);
                }
                else if (path.Keyword.Value.ToLower() == keyword.Value.ToLower() && !path.Keyword.Visited)
                {
                    outgoing.Add(path.Synonym);
                    result.Add(path.Synonym.Value);
                }
            }

            foreach (Node node in outgoing)
            {
                GetSynonyms(node, data, ref result);
            }

        }

        public static List<Path> ConvertToNodes(IEnumerable<SynonymModel> synonyms)
        {
            return synonyms.Select(synonym => new Path(new Node(synonym.Keyword), new Node(synonym.Synonym))).ToList();
        }
    }
}
