﻿// <auto-generated />
using System;
using DesafioWarren.Infrastructure.EntityFramework.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DesafioWarren.Infrastructure.Migrations
{
    [DbContext(typeof(AccountsDbContext))]
    [Migration("20210318074122_SetDefaultValue_LastModifiedColumn_AccountBalance")]
    partial class SetDefaultValue_LastModifiedColumn_AccountBalance
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("DesafioWarren.Domain.Aggregates.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Cpf")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("LastModified")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Number")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("DesafioWarren.Domain.Entities.AccountBalance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Balance")
                        .HasPrecision(19, 4)
                        .HasColumnType("decimal(19,4)");

                    b.Property<string>("Currency")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("LastModified")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("AccountBalance");
                });

            modelBuilder.Entity("DesafioWarren.Domain.Entities.AccountTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("AccountBalanceId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Occurrence")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("TransactionType")
                        .HasColumnType("int");

                    b.Property<decimal>("TransactionValue")
                        .HasPrecision(19, 4)
                        .HasColumnType("decimal(19,4)");

                    b.HasKey("Id");

                    b.HasIndex("AccountBalanceId");

                    b.ToTable("AccountTransaction");
                });

            modelBuilder.Entity("DesafioWarren.Domain.Entities.AccountBalance", b =>
                {
                    b.HasOne("DesafioWarren.Domain.Aggregates.Account", null)
                        .WithOne("_accountBalance")
                        .HasForeignKey("DesafioWarren.Domain.Entities.AccountBalance", "AccountId");
                });

            modelBuilder.Entity("DesafioWarren.Domain.Entities.AccountTransaction", b =>
                {
                    b.HasOne("DesafioWarren.Domain.Entities.AccountBalance", null)
                        .WithMany("_transactions")
                        .HasForeignKey("AccountBalanceId");
                });

            modelBuilder.Entity("DesafioWarren.Domain.Aggregates.Account", b =>
                {
                    b.Navigation("_accountBalance");
                });

            modelBuilder.Entity("DesafioWarren.Domain.Entities.AccountBalance", b =>
                {
                    b.Navigation("_transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
