﻿// <auto-generated />
using System;
using Infrastructure.DbContexts.PostgreSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.DbContexts.PostgreSql.Migrations
{
    [DbContext(typeof(PostgreSqlDbContext))]
    [Migration("20190526172228_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Infrastructure.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessibleAccountId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("accessible_accounts");
                });

            modelBuilder.Entity("Infrastructure.Entities.History", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessibleAccountName");

                    b.Property<int>("AccountId");

                    b.Property<int?>("AccountId1");

                    b.Property<DateTime>("LoginDateTime");

                    b.Property<DateTime?>("LogoutDateTime");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("AccountId1");

                    b.ToTable("accessible_accounts_histories");
                });

            modelBuilder.Entity("Infrastructure.Entities.History", b =>
                {
                    b.HasOne("Infrastructure.Entities.Account", "AccessibleAccount")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Infrastructure.Entities.Account")
                        .WithMany("AccessHistories")
                        .HasForeignKey("AccountId1");
                });
#pragma warning restore 612, 618
        }
    }
}
