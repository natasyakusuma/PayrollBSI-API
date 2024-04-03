using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PayrollBSI.Data.Models;
using PayrollBSI.Domain;

namespace PayrollBSI.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<PayrollDetail> PayrollDetails { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Tax> Taxes { get; set; }



    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Payrolls;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendance>(entity =>
        {
			entity.HasKey(e => e.AttendanceId).HasName("PK__Attendance__8B69263C992F8474");

			entity.HasOne(d => d.Employee).WithMany(p => p.Attendances)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Attendanc__Emplo__403A8C7D");

		});

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeID).HasName("PK__Employee__7AD04FF1CDEA6CBF");

            entity.Property(e => e.EmployeeID).ValueGeneratedNever();

            entity.HasOne(d => d.Position).WithMany(p => p.Employees)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employee__Positi__3D5E1FD2");
        });

        modelBuilder.Entity<PayrollDetail>(entity =>
        {
            entity.HasKey(e => e.PayrollDetailID).HasName("PK__PayrollD__010127A9ED150416");

            entity.HasOne(d => d.Employee).WithMany(p => p.PayrollDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PayrollDe__Emplo__6B24EA82");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.PositionId).HasName("PK__Position__60BB9A599BA7784F");

            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(true);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE3A2147E6D8");
        });

        modelBuilder.Entity<Tax>(entity =>
        {
            entity.HasKey(e => e.TaxId).HasName("PK__Tax__711BE08CC6214B87");

            entity.Property(e => e.TaxId).ValueGeneratedNever();
        });

        modelBuilder.Entity<EmployeeDetails>().HasNoKey().ToView(null);
        modelBuilder.Entity<AttendanceDetails>().HasNoKey().ToView(null);
        modelBuilder.Entity<PayrollDetailsCreate>().HasNoKey().ToView(null);
     


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
