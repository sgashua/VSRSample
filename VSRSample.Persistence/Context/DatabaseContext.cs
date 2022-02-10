using Microsoft.EntityFrameworkCore;
using VSRSample.Domain.Constants;
using VSRSample.Domain.Entities;

namespace VSRSample.Persistence.Context
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;

        public override int SaveChanges()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            DateTime date = DateTime.Now;

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).CreatedBy = ProjectConstant.DefaultCreatedBy; // or = User.Identity.Name ?? ProjectConstant.DefaultCreatedBy;
                    ((BaseEntity)entity.Entity).CreatedDate = date;
                }
                else if (entity.State == EntityState.Modified)
                {
                    ((BaseEntity)entity.Entity).ModifiedBy = ProjectConstant.DefaultCreatedBy; // or = User.Identity.Name ?? ProjectConstant.DefaultCreatedBy;
                    ((BaseEntity)entity.Entity).ModifiedDate = date;
                }
            }
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Employee_Company");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
