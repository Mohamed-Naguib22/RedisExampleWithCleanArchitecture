using Microsoft.EntityFrameworkCore;
using RedisExampleWithCleanArchitecture.Domain.Entities.ProductEntities;
using RedisExampleWithCleanArchitecture.Persistence.Extensions.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace RedisExampleWithCleanArchitecture.Persistence.Context
{
    public class ApplicantionDbContext : DbContext
    {
        public ApplicantionDbContext(DbContextOptions<ApplicantionDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }

        public DbSet<Product> Products { get; set; }
    } 
}
