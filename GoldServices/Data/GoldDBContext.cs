using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using GoldServices.Models;

namespace GoldServices.Data
{
    internal partial class GoldDBContext : DbContext
    {
        public GoldDBContext()
        {
        }

        public GoldDBContext(DbContextOptions<GoldDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<CosPro> CosPros { get; set; } = null!;
        public virtual DbSet<Costumer> Costumers { get; set; } = null!;
        public virtual DbSet<Kart> Karts { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-39JL9IM;Initial Catalog=GoldDB;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasOne(d => d.IdComNavigation)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.IdCom)
                    .HasConstraintName("FK_categories_Companies");
            });

            modelBuilder.Entity<CosPro>(entity =>
            {
                entity.HasOne(d => d.IdCosNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCos)
                    .HasConstraintName("FK_Cos_Pro_Costumers");

                entity.HasOne(d => d.IdProNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPro)
                    .HasConstraintName("FK_Cos_Pro_Products");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasOne(d => d.IdCosNavigation)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.IdCos)
                    .HasConstraintName("FK_Messages_Costumers");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(d => d.IdCosNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCos)
                    .HasConstraintName("FK_Order_Costumers");

                entity.HasOne(d => d.IdProNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPro)
                    .HasConstraintName("FK_Order_Products");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne(d => d.IdCatNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdCat)
                    .HasConstraintName("FK_Products_categories");

                entity.HasOne(d => d.IdKartNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdKart)
                    .HasConstraintName("FK_Products_Kart");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
