﻿using System;
using dz5._1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace dz5._1.Controller
{
    [DbContext(typeof(Context))]
    internal class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("dz5._1.Models.Message", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer")
                    .HasColumnName("id")
                    .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                b.Property<int?>("FromUserId")
                    .HasColumnType("integer")
                    .HasColumnName("from_user_id");

                b.Property<bool>("Received")
                    .HasColumnType("boolean");

                b.Property<string>("Text")
                    .HasColumnType("text")
                    .HasColumnName("text");

                b.Property<int?>("ToUserId")
                    .HasColumnType("integer")
                    .HasColumnName("to_user_id");

                b.HasKey("Id")
                    .HasName("message_pkey");

                b.HasIndex("FromUserId");

                b.HasIndex("ToUserId");

                b.ToTable("Messages");
            });

            modelBuilder.Entity("dz5._1.Models.User", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer")
                    .HasColumnName("id")
                    .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                b.Property<string>("Name")
                    .HasMaxLength(255)
                    .HasColumnType("character varying(255)")
                    .HasColumnName("name");

                b.HasKey("Id")
                    .HasName("user_pkey");

                b.ToTable("Users");
            });

            modelBuilder.Entity("dz5._1.Models.Message", b =>
            {
                b.HasOne("dz5._1.Models.User", "FromUser")
                    .WithMany("FromMessages")
                    .HasForeignKey("FromUserId")
                    .HasConstraintName("messages_from_user_id_fkey");

                b.HasOne("dz5._1t.Models.User", "ToUser")
                    .WithMany("ToMessages")
                    .HasForeignKey("ToUserId")
                    .HasConstraintName("messages_to_user_id_fkey");

                b.Navigation("FromUser");

                b.Navigation("ToUser");
            });

            modelBuilder.Entity("dz5._1.Models.User", b =>
            {
                b.Navigation("FromMessages");

                b.Navigation("ToMessages");
            });
#pragma warning restore 612, 618
        }
    }
}
