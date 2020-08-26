using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Synonymous.DataContext;
using Synonymous.Models;
using Synonymous.Utils;

namespace Synonymous.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly SynonymDbContext _context;

        public SearchController(SynonymDbContext context)
        {
            _context = context;
        }

        [HttpGet("{keyword}")]
        public IEnumerable<string> Get(string keyword)
        {
            var result = new List<string>();
            var synonyms = GraphUtils.ConvertToNodes(_context.Synonyms.ToList());
            var entryNode = new Node(keyword);

            GraphUtils.GetSynonyms(entryNode, synonyms, ref result);

            return result;
        }
    }
}
