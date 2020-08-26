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
                    Keyword = "Example",
                    Synonym = "Case"
                },
                new SynonymModel
                {
                    Id = 2,
                    Keyword = "Connection",
                    Synonym = "Network"
                }
            });

            context.SaveChanges();
        }
    }
}
