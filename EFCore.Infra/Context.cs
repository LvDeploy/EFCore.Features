using EFCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Reflection;

namespace EFCore.Infra
{
    public class Context : DbContext
    {
        //public DbSet<Livro> Livro { get; set; }

        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(Context).Assembly;

            modelBuilder.ApplyConfigurationsFromAssembly(assembly);            

            base.OnModelCreating(modelBuilder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter("EFCore.Features.Program", LogLevel.Debug)
                    .AddConsole();
            });

            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder
                .UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=TREINAMENTO.EFCORE;Integrated Security=True");
        }
    }
}
