using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SensitiveWords.Api.Models;

namespace Sensitivewords.Api.Data
{
    public class SensitiveWordsDbContext : DbContext
    {
        public SensitiveWordsDbContext(DbContextOptions<SensitiveWordsDbContext> options)
            : base(options)
        {
        }

        // Define a DbSet for each entity type you want to include in your model.
        public DbSet<SensitiveWord> SensitiveWords { get; set; }

        // Optionally, you can override OnConfiguring to configure the database (and other options) to be used for this context.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Get configuration from appsettings.json
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connectionString = configuration.GetConnectionString("SensitiveWordsDatabase");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        // Optionally, you can override OnModelCreating to further configure the model that was discovered by convention from the entity types.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure your entity mappings here.
        }
    }


}
