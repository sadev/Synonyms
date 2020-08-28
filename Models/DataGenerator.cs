using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Synonymous.DataContext;

namespace Synonymous.Models
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new SynonymDbContext(serviceProvider.GetRequiredService<DbContextOptions<SynonymDbContext>>());

            if (context.Synonyms.Any())
            {
                return;   // Database has been seeded
            }

            context.Synonyms.AddRange(new List<SynonymModel>()
            {
                new SynonymModel
                {
                    Id = 1,
                    Keyword = "Fair",
                    Synonym = "Just"
                },
                new SynonymModel
                {
                    Id = 2,
                    Keyword = "Just",
                    Synonym = "Objective"
                },
                new SynonymModel
                {
                    Id = 3,
                    Keyword = "Honest",
                    Synonym = "Fair"
                },
                new SynonymModel
                {
                    Id = 4,
                    Keyword = "Honest",
                    Synonym = "Trustworthy"
                },
                new SynonymModel
                {
                    Id = 5,
                    Keyword = "Fair",
                    Synonym = "Sincere"
                },
                new SynonymModel
                {
                    Id = 6,
                    Keyword = "Honorable",
                    Synonym = "Honest"
                },
                new SynonymModel
                {
                    Id = 7,
                    Keyword = "Intelligent",
                    Synonym = "Smart"
                },
                new SynonymModel
                {
                    Id = 8,
                    Keyword = "Bright",
                    Synonym = "Smart"
                },
                new SynonymModel
                {
                    Id = 9,
                    Keyword = "Smart",
                    Synonym = "Sharp"
                },
                new SynonymModel
                {
                    Id = 10,
                    Keyword = "Sharp",
                    Synonym = "Brilliant"
                },
            });

            context.SaveChanges();
        }
    }
}
