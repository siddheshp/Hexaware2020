﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TestEmsWebApp.Data;

namespace TestEmsWebApp.Migrations
{
    [DbContext(typeof(EmployeeContext))]
    [Migration("20200914184704_Migrationv3")]
    partial class Migrationv3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("TestEmsWebApp.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateOfJoining")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Phone")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfJoining = new DateTime(2020, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "param@hexaware.com",
                            Gender = 2,
                            Name = "Param",
                            Phone = 9988990098L
                        },
                        new
                        {
                            Id = 2,
                            DateOfJoining = new DateTime(2020, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "shona@hexaware.com",
                            Gender = 1,
                            Name = "Shona",
                            Phone = 9988990098L
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
