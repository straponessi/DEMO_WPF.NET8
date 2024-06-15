using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DEMO_WPF.NET8.Models;

public partial class ServiceHardContext : DbContext
{
    public ServiceHardContext()
    {
    }

    public ServiceHardContext(DbContextOptions<ServiceHardContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Request> Requests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-7CAOH5E\\SQL;Database=ServiceHard;Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Request>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.Customer)
                .HasMaxLength(150)
                .HasColumnName("customer");
            entity.Property(e => e.DateAllows)
                .HasColumnType("datetime")
                .HasColumnName("date_allows");
            entity.Property(e => e.DateEnd)
                .HasColumnType("datetime")
                .HasColumnName("date_end");
            entity.Property(e => e.DateStart)
                .HasColumnType("datetime")
                .HasColumnName("date_start");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.TechName)
                .HasMaxLength(50)
                .HasColumnName("tech_name");
            entity.Property(e => e.TechType)
                .HasMaxLength(50)
                .HasColumnName("tech_type");
            entity.Property(e => e.Worker)
                .HasMaxLength(150)
                .HasColumnName("worker");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
