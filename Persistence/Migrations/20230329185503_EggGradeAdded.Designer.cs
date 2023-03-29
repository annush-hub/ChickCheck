﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230329185503_EggGradeAdded")]
    partial class EggGradeAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Barn", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EggGradeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeactivated")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("TemperatureInCelsius")
                        .HasColumnType("real");

                    b.Property<float>("TemperatureInFahrenheit")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("EggGradeId");

                    b.ToTable("Barns");
                });

            modelBuilder.Entity("Domain.EggGrade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GradeEU")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GradeUA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EggGrades");
                });

            modelBuilder.Entity("Domain.Barn", b =>
                {
                    b.HasOne("Domain.EggGrade", "EggGrade")
                        .WithMany("Barns")
                        .HasForeignKey("EggGradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EggGrade");
                });

            modelBuilder.Entity("Domain.EggGrade", b =>
                {
                    b.Navigation("Barns");
                });
#pragma warning restore 612, 618
        }
    }
}