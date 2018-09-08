using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HandmadeCakes.Models
{
    public partial class HandmadeCakesContext : DbContext
    {        
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderToppings> OrderToppings { get; set; }
        public virtual DbSet<Shapes> Shapes { get; set; }
        public virtual DbSet<Toppings> Toppings { get; set; }
        public virtual DbSet<User> User { get; set; }

        public HandmadeCakesContext(DbContextOptions<HandmadeCakesContext> options) : base(options) { }
                    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DeliveryDate).HasColumnType("date");

                entity.Property(e => e.Message).HasMaxLength(20);

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.Price).HasColumnType("decimal(9, 4)");

                entity.Property(e => e.Toppings).HasMaxLength(1);

                entity.HasOne(d => d.Shape)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.ShapeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Shapes");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Order_User");
            });

            modelBuilder.Entity<OrderToppings>(entity =>
            {
                entity.ToTable("Order_Toppings");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderToppings)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Toppings_Order");

                entity.HasOne(d => d.Toppings)
                    .WithMany(p => p.OrderToppings)
                    .HasForeignKey(d => d.ToppingsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Toppings_Toppings");
            });

            modelBuilder.Entity<Shapes>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(8, 4)");
            });

            modelBuilder.Entity<Toppings>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Price).HasColumnType("decimal(8, 4)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Telephone).HasMaxLength(15);
            });
        }
    }
}
