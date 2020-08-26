using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Synonymous.Models;

namespace Synonymous.DataContext
{
    public class SynonymDbContext: DbContext
    {
        public SynonymDbContext(DbContextOptions<SynonymDbContext> options)
            : base(options)
        {
        }
        public DbSet<SynonymModel> Synonyms { get; set; }
    }
}
