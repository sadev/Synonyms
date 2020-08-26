using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Synonymous.Models
{
    public class SynonymModel
    {
        [Key]
        public int Id { get; set; }
        public string Keyword { get; set; }
        public string Synonym { get; set; }
    }
}
