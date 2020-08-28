using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Synonymous.DataContext;
using Synonymous.Models;
using Synonymous.Utils;

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
            if (model.Keyword.ToLower() == model.Synonym.ToLower()) {
                throw new SynonymException($"Keyword and Synonym can not be same word.");
            }

            if (ValidateSynonymPair(model)) {
                throw new SynonymException($"'{model.Keyword}' and '{model.Synonym}' synonym pair already exists.");
            }
            //Determine the next ID
            var id = _context.Synonyms.Select(x => x.Id).Max() + 1; //In memory DB...that's why.
            model.Id = id;

            _context.Synonyms.Add(model);
            _context.SaveChanges();
        }

        [HttpPut]
        public void Put(SynonymModel model)
        {
            if (model.Keyword.ToLower() == model.Synonym.ToLower()) {
                throw new SynonymException($"Keyword and Synonym can not be same word.");
            }

            if (ValidateSynonymPairOnUpdate(model)) {
                throw new SynonymException($"Keyword {model.Keyword} and Synonym {model.Synonym} pair already exists.");
            }

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

        private bool ValidateSynonymPair(SynonymModel model) {
            return _context.Synonyms.Any(s => s.Keyword == model.Keyword && s.Synonym == model.Synonym) ||
                   _context.Synonyms.Any(s => s.Keyword == model.Synonym && s.Synonym == model.Keyword);
        }

        private bool ValidateSynonymPairOnUpdate(SynonymModel model)
        {
            return _context.Synonyms.Any(s => s.Keyword == model.Keyword && s.Synonym == model.Synonym && s.Id != model.Id) ||
                   _context.Synonyms.Any(s => s.Keyword == model.Synonym && s.Synonym == model.Keyword);
        }
    }
}
