using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace workkkk.Entity;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=WORK_SHOP;Username=postgres;Password=Poplol33_");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("customers_pkey");

            entity.ToTable("customers");

            entity.HasIndex(e => e.Code, "customers_code_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .HasColumnName("code");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Isactive)
                .HasDefaultValueSql("'1'::\"bit\"")
                .HasColumnType("bit(1)")
                .HasColumnName("isactive");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("orders_pkey");

            entity.ToTable("orders");

            entity.HasIndex(e => e.Orderno, "orders_orderno_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Customerid).HasColumnName("customerid");
            entity.Property(e => e.Orderdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("orderdate");
            entity.Property(e => e.Orderno)
                .HasMaxLength(30)
                .HasColumnName("orderno");
            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Qty).HasColumnName("qty");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.Totalamount)
                .HasPrecision(18, 2)
                .HasColumnName("totalamount");
            entity.Property(e => e.Unitprice)
                .HasPrecision(18, 2)
                .HasColumnName("unitprice");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Customerid)
                .HasConstraintName("fk_orders_customer");

            entity.HasOne(d => d.Product).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Productid)
                .HasConstraintName("fk_orders_product");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("products_pkey");

            entity.ToTable("products");

            entity.HasIndex(e => e.Productcode, "products_productcode_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createat");
            entity.Property(e => e.Isactive)
                .HasDefaultValueSql("'1'::\"bit\"")
                .HasColumnType("bit(1)")
                .HasColumnName("isactive");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasPrecision(18, 2)
                .HasColumnName("price");
            entity.Property(e => e.Productcode)
                .HasMaxLength(30)
                .HasColumnName("productcode");
            entity.Property(e => e.Stockqty).HasColumnName("stockqty");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
