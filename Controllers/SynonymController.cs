using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Synonymous.DataContext;
using Synonymous.Models;

namespace Synonymous.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SynonymController : ControllerBase
    {
        private readonly SynonymDbContext _context;

        public SynonymController(SynonymDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<SynonymModel>> Get()
        {
            int skip =Convert.ToInt32(Request.Query["$skip"]);
            int take = Convert.ToInt32(Request.Query["$top"]);
            var synonyms = _context.Synonyms.ToList();
            return new JsonResult(new { result = synonyms.Skip(skip).Take(take), Count = synonyms.Count });
        }
            
        [HttpGet("{id}")]
        public ActionResult<SynonymModel> Get(int id)
        {
            return _context.Synonyms.Find(id);
        }

        [HttpPost]
        public void Post(SynonymModel model)
        {
            //Determine the next ID
            var id = _context.Synonyms.Select(x => x.Id).Max() + 1; //In memory DB...that's why.
            model.Id = id;

            _context.Synonyms.Add(model);
            _context.SaveChanges();
        }

        [HttpPut]
        public void Put(SynonymModel model)
        {
            _context.Synonyms.Update(model);
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]

        public void Delete(int id)
        {
            var synonym = _context.Synonyms.Find(id);
            if (synonym != null)
            {
                _context.Synonyms.Remove(synonym);
                _context.SaveChanges();
            }
        }
    }
}
