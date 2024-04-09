using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace _001_Basics.Models;

public partial class DbPruebasJwtContext : DbContext
{
    public DbPruebasJwtContext()
    {
    }

    public DbPruebasJwtContext(DbContextOptions<DbPruebasJwtContext> options)
        : base(options)
    {
    }

    public virtual DbSet<RefreshTokenHistorial> RefreshTokenHistorials { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RefreshTokenHistorial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RefreshT__3214EC07701DF984");

            entity.ToTable("RefreshTokenHistorial");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ExpirationDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasComputedColumnSql("(case when [ExpirationDate]<getdate() then CONVERT([bit],(1)) else CONVERT([bit],(0)) end)", false);
            entity.Property(e => e.RefreshToken)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Token)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.RefreshTokenHistorials)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__RefreshTo__UserI__3B75D760");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC0736117C25");

            entity.Property(e => e.Upassword)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UPassword");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
