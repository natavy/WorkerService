using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;



namespace RandomGuid.Web.Models
{
    public partial class GuidDbContext : DbContext
    {
        public GuidDbContext()
        {
        }

        public GuidDbContext(DbContextOptions<GuidDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GuidStatusViewModel> GuidStatus { get; set; }
        public virtual DbSet<GuidViewModel> Guids { get; set; }
        public virtual DbSet<TextFileViewModel> TextFiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=NATASHA-PC\\SQLEXPRESS; DataBase=GuidDb; Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuidStatusViewModel>(entity =>
            {
                entity.HasKey(e => e.StatusId);

                entity.Property(e => e.StatusId).ValueGeneratedNever();
            });

            modelBuilder.Entity<GuidViewModel>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
                //entity.HasMany(s => s.Statuses);
            });
           
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        public override int SaveChanges()
        {
            var selectedEntityList = ChangeTracker.Entries()
                                    .Where(x => x.Entity is GuidViewModel &&
                                    (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in selectedEntityList)
            {

                ((GuidViewModel)entity.Entity).ModifiedDate = DateTime.Now;
                //((GuidViewModel)entity.Entity).CreationDate = DateTime.Now; ;
            }

            return base.SaveChanges();
        }
    }
}
