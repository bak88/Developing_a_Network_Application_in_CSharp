using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar5._1.Models
{
    public class ChatContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public ChatContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine)
                .UseLazyLoadingProxies()
                .UseNpgsql("Host=localhost;Username=postgres;Password=example;Database=ChatDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("message_pkey");

                entity.ToTable("Message");

                entity.Property(i => i.Id).HasColumnName("id");
                entity.Property(t => t.Text).HasColumnName("text");
                entity.Property(x => x.ToUserId).HasColumnName("to_user_id");
                entity.Property(x => x.FromUserId).HasColumnName("from_user_id");

                entity.HasOne(d => d.FromUser)
                    .WithMany(d => d.SentMessages)
                    .HasForeignKey(e => e.FromUserId)                    
                    .HasConstraintName("messages_from_user_id_fkey");

                entity.HasOne(d => d.ToUser)
                    .WithMany(d => d.ReceivedMessages)
                    .HasForeignKey(e => e.ToUserId)                    
                    .HasConstraintName("messages_to_user_id_fkey");

            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(x => x.Id).HasName("user_pkey");

                entity.ToTable("Users");

                entity.Property(i => i.Id).HasColumnName("id");
                entity.Property(n => n.Name).HasMaxLength(255).HasColumnName("name");


            });
            base.OnModelCreating(modelBuilder);





        }


    }
}
