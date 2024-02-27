using System;
using System.Collections.Generic;
using ProductionDomain.Model;
using Microsoft.EntityFrameworkCore;

namespace ProductionInfrastructure;

public partial class Isttp1FvContext : DbContext
{
    public Isttp1FvContext()
    {
    }

    public Isttp1FvContext(DbContextOptions<Isttp1FvContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Factory> Factories { get; set; }

    public virtual DbSet<FactoryProduct> FactoryProducts { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ReqProduct> ReqProducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-4H8MMS3\\SQLEXPRESS; Database=isttp1FV; Trusted_Connection=True; TrustServerCertificate=True; ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.ClientName).HasColumnType("text");
            entity.Property(e => e.Contacts).HasColumnType("text");
        });

        modelBuilder.Entity<Factory>(entity =>
        {
            entity.Property(e => e.FactoryId).HasColumnName("FactoryID");
            entity.Property(e => e.Adress).HasColumnType("text");
            entity.Property(e => e.FactoryName).HasColumnType("text");
            entity.Property(e => e.Maintenance).HasColumnType("text");
        });

        modelBuilder.Entity<FactoryProduct>(entity =>
        {
            entity.Property(e => e.FactoryProductId).HasColumnName("FactoryProductID");
            entity.Property(e => e.FactoryId).HasColumnName("FactoryID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Factory).WithMany(p => p.FactoryProducts)
                .HasForeignKey(d => d.FactoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FactoryProducts_Factories");

            entity.HasOne(d => d.Product).WithMany(p => p.FactoryProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FactoryProducts_Products");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.FactoryId).HasColumnName("FactoryID");
            entity.Property(e => e.OrderStatus).HasColumnType("text");

            entity.HasOne(d => d.Client).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Clients");

            entity.HasOne(d => d.Factory).WithMany(p => p.Orders)
                .HasForeignKey(d => d.FactoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Factories");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductDescription).HasColumnType("text");
            entity.Property(e => e.ProductName).HasColumnType("text");
        });

        modelBuilder.Entity<ReqProduct>(entity =>
        {
            entity.Property(e => e.ReqProductId).HasColumnName("ReqProductID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Order).WithMany(p => p.ReqProducts)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReqProducts_Orders");

            entity.HasOne(d => d.Product).WithMany(p => p.ReqProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReqProducts_Products");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
