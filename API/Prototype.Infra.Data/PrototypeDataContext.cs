using Microsoft.EntityFrameworkCore;
using Prototype.Domain.Entities;
using Prototype.Infra.Data.Interfaces;
using System;
using System.Linq;

namespace Prototype.Infra.Data
{
    public class PrototypeDataContext : DbContext
    {

        public PrototypeDataContext(DbContextOptions<PrototypeDataContext> options) : base(options)
        {
            Database.AutoTransactionsEnabled = false;
        }

        public DbSet<Promocao> Promocoes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Carrinho> Carrinho { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var mappings = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(IEntityMapping).IsAssignableFrom(x) && !x.IsAbstract)
                .ToList();

            foreach (var type in mappings)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
        }
    }
}
