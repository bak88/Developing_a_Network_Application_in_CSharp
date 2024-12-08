using System;
using System.Collections.Generic;
using Lecture5._4_CodeFirst.Model;
using Microsoft.EntityFrameworkCore;


namespace Lecture5._4_CodeFirst
{
    public partial class TestContext : DbContext
    {
        public TestContext()
        {
        }

        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {
        }

        public virtual DbSet<Message> Messages { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Gender> Genders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine)
                          .UseNpgsql("Host=localhost;Username=postgres;Password=example;Database=Test1")
                          .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("messages_pkey");

                entity.ToTable("messages");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Message1).HasColumnName("message");
                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User).WithMany(p => p.Messages)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("messages_user_id_fkey");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("users_pkey");

                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(g => g.GenderId)
                    .HasConversion<int>();
            });

            modelBuilder.Entity<Gender>()
                    .Property(e => e.GenderId)
                    .HasConversion<int>();

            modelBuilder.Entity<Gender>()
                        .HasData(Enum.GetValues<GenderId>()
                                     .Cast<GenderId>()
                                     .Select(e => new Gender()
                                     {
                                         GenderId = e,
                                         Name = e.ToString()
                                     }));

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}