using Microsoft.EntityFrameworkCore;
using RedisExampleWithCleanArchitecture.Domain.ProductEntities;
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

        }

        public DbSet<Product> Products { get; set; }
    } 
}
