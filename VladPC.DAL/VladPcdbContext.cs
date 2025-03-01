using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using VladPC.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace VladPC.DAL;

public partial class VladPcdbContext : IdentityDbContext<User, IdentityRole<int>, int>
{
    public VladPcdbContext()
    {
        Database.EnsureCreated();
    }

    public VladPcdbContext(DbContextOptions<VladPcdbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderRow> OrderRows { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Promocode> Promocodes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=VladPCDB;Username=postgres;Password=fgvcdrt");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Order_pkey");

            entity.ToTable("Order");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.Promocode).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PromocodeId)
                .HasConstraintName("Order_PromocodeId_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("Order_UserId_fkey");
        });

        modelBuilder.Entity<OrderRow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("OrderRow_pkey");

            entity.ToTable("OrderRow");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Order).WithMany(p => p.OrderRows)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("OrderRow_OrderId_fkey");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderRows)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("OrderRow_ProductId_fkey");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Product_pkey");

            entity.ToTable("Product");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.CountRam).HasColumnName("CountRAM");
            entity.Property(e => e.CountSsdm2).HasColumnName("CountSSDM2");
            entity.Property(e => e.Tdp).HasColumnName("TDP");
        });

        modelBuilder.Entity<Promocode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Promocode_pkey");

            entity.ToTable("Promocode");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("User_pkey");

            entity.ToTable("User");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
