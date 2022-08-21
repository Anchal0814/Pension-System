﻿// <auto-generated />
using System;
using APIPension.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APIPension.Migrations
{
    [DbContext(typeof(PensionerContext))]
    [Migration("20220820091752_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APIPension.Models.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AadhaarNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("APIPension.Models.Pensioner", b =>
                {
                    b.Property<int>("PensionerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AadhaarNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("AccountNumber")
                        .HasColumnType("bigint");

                    b.Property<int>("Allowances")
                        .HasColumnType("int");

                    b.Property<int>("BankCharge")
                        .HasColumnType("int");

                    b.Property<string>("BankName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("PAN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("PensionAmount")
                        .HasColumnType("real");

                    b.Property<string>("PensionType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PensionerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("SalaryEarned")
                        .HasColumnType("real");

                    b.HasKey("PensionerId");

                    b.ToTable("Pensioner");
                });
#pragma warning restore 612, 618
        }
    }
}
