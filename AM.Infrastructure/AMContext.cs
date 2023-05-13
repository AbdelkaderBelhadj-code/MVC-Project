using AM.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Infrastructure.Configurations;
using AM.ApplicationCore.Domain;

namespace AM.Infrastructure
{
    public class AMContext: DbContext
    {
        public DbSet<Invite> Invite { get; set; }
        public DbSet<Fete> Fete { get; set; }
        public DbSet<Invitation> Invitation { get; set; }
        public DbSet<Salle> Salle { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
              Initial Catalog=FeteDB;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }


        public AMContext()
        {
            
        }

        public AMContext(DbContextOptions<AMContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InvitationConfiguration());

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder
                .Properties<string>()
                .HaveMaxLength(150);
        }



    }
}
