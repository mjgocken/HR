using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using HR.EF.Models;

#nullable disable

namespace HR.EF.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Employment> Employments { get; set; }
        public virtual DbSet<EmploymentPay> EmploymentPays { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<VEmployee> VEmployees { get; set; }
        public virtual DbSet<VEmployment> VEmployments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("C##_UD_MJGOCKEN")
                .HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CountryGuid)
                    .HasName("COUNTRIES_PK");

                entity.Property(e => e.CountryGuid).IsUnicode(false);

                entity.Property(e => e.CountryName).IsUnicode(false);

                entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedId)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RegionGuid).IsUnicode(false);

                entity.Property(e => e.UpdatedDate).ValueGeneratedOnAdd();

                entity.Property(e => e.UpdatedId)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.RegionGu)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.RegionGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("COUNTRIES_FK1");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepartmentGuid)
                    .HasName("DEPARTMENTS_PK");

                entity.Property(e => e.DepartmentGuid).IsUnicode(false);

                entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedId)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DepartmentName).IsUnicode(false);

                entity.Property(e => e.LocationGuid).IsUnicode(false);

                entity.Property(e => e.ManagerGuid).IsUnicode(false);

                entity.Property(e => e.UpdatedDate).ValueGeneratedOnAdd();

                entity.Property(e => e.UpdatedId)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.LocationGu)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.LocationGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DEPARTMENTS_FK1");

                entity.HasOne(d => d.ManagerGu)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.ManagerGuid)
                    .HasConstraintName("DEPARTMENTS_FK2");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeGuid)
                    .HasName("EMPLOYEES_PK");

                entity.Property(e => e.EmployeeGuid).IsUnicode(false);

                entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedId)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.PhoneNumber).IsUnicode(false);

                entity.Property(e => e.UpdatedDate).ValueGeneratedOnAdd();

                entity.Property(e => e.UpdatedId)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Employment>(entity =>
            {
                entity.HasKey(e => e.EmploymentGuid)
                    .HasName("EMPLOYMENT_PK");

                entity.Property(e => e.EmploymentGuid).IsUnicode(false);

                entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedId)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DepartmentGuid).IsUnicode(false);

                entity.Property(e => e.EmployeeGuid).IsUnicode(false);

                entity.Property(e => e.JobGuid).IsUnicode(false);

                entity.Property(e => e.UpdatedDate).ValueGeneratedOnAdd();

                entity.Property(e => e.UpdatedId)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.DepartmentGu)
                    .WithMany(p => p.Employments)
                    .HasForeignKey(d => d.DepartmentGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EMPLOYMENT_FK2");

                entity.HasOne(d => d.EmployeeGu)
                    .WithMany(p => p.Employments)
                    .HasForeignKey(d => d.EmployeeGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EMPLOYMENT_FK1");

                entity.HasOne(d => d.JobGu)
                    .WithMany(p => p.Employments)
                    .HasForeignKey(d => d.JobGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EMPLOYMENT_FK3");
            });

            modelBuilder.Entity<EmploymentPay>(entity =>
            {
                entity.HasKey(e => e.EmploymentPayGuid)
                    .HasName("EMPLOYMENT_PAY_PK");

                entity.Property(e => e.EmploymentPayGuid).IsUnicode(false);

                entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedId)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.EmploymentGuid)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Salary).ValueGeneratedOnAdd();

                entity.Property(e => e.UpdatedDate).ValueGeneratedOnAdd();

                entity.Property(e => e.UpdatedId)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.EmploymentGu)
                    .WithMany(p => p.EmploymentPays)
                    .HasForeignKey(d => d.EmploymentGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("EMPLOYMENT_PAY_FK1");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.HasKey(e => e.JobGuid)
                    .HasName("JOBS_PK");

                entity.Property(e => e.JobGuid).IsUnicode(false);

                entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedId)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.JobTitle).IsUnicode(false);

                entity.Property(e => e.MaxSalary)
                    .HasPrecision(6)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.MinSalary)
                    .HasPrecision(6)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UpdatedDate).ValueGeneratedOnAdd();

                entity.Property(e => e.UpdatedId)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.LocationGuid)
                    .HasName("LOCATIONS_PK");

                entity.Property(e => e.LocationGuid).IsUnicode(false);

                entity.Property(e => e.City).IsUnicode(false);

                entity.Property(e => e.CountryGuid)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedId)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.PostalCode)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.StateProvince).IsUnicode(false);

                entity.Property(e => e.StreetAddress).IsUnicode(false);

                entity.Property(e => e.UpdatedDate).ValueGeneratedOnAdd();

                entity.Property(e => e.UpdatedId)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.CountryGu)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.CountryGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("LOCATIONS_FK1");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasKey(e => e.RegionGuid)
                    .HasName("REGIONS_PK");

                entity.Property(e => e.RegionGuid).IsUnicode(false);

                entity.Property(e => e.CreatedDate).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedId)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RegionName).IsUnicode(false);

                entity.Property(e => e.UpdatedDate).ValueGeneratedOnAdd();

                entity.Property(e => e.UpdatedId)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<VEmployee>(entity =>
            {
                entity.ToView("V_EMPLOYEE");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.EmployeeGuid).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.PhoneNumber).IsUnicode(false);
            });

            modelBuilder.Entity<VEmployment>(entity =>
            {
                entity.ToView("V_EMPLOYMENT");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.EmployeeGuid).IsUnicode(false);

                entity.Property(e => e.EmploymentGuid).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.PhoneNumber).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
