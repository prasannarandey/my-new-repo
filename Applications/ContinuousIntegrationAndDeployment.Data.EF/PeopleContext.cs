using ContinuousIntegrationAndDeployment.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ContinuousIntegrationAndDeployment.Data.EF
{
    public class PeopleContext : DbContext
    {
        private readonly string _connectionString;

        public PeopleContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString, b =>
                 b.MigrationsAssembly("ContinuousIntegrationAndDeployment.Data.EF"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
