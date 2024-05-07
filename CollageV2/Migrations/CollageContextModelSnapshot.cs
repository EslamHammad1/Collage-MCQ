﻿// <auto-generated />
using System;
using CollageV2.DataEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CollageV2.Migrations
{
    [DbContext(typeof(CollageContext))]
    partial class CollageContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CollageV2.Models.Admin", b =>
                {
                    b.Property<int>("A_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("A_Id"));

                    b.Property<string>("AD_FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("A_Id");

                    b.ToTable("admins");
                });

            modelBuilder.Entity("CollageV2.Models.Course", b =>
                {
                    b.Property<int>("Crs_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Crs_Id"));

                    b.Property<int?>("CrsDuration")
                        .HasColumnType("int");

                    b.Property<string>("CrsName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Ex_Id")
                        .HasColumnType("int");

                    b.HasKey("Crs_Id");

                    b.ToTable("courses");
                });

            modelBuilder.Entity("CollageV2.Models.Exam", b =>
                {
                    b.Property<int>("Ex_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Ex_Id"));

                    b.Property<int?>("Crs_Id")
                        .HasColumnType("int");

                    b.Property<int?>("Crs_Id1")
                        .HasColumnType("int");

                    b.Property<string>("Discruption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NumOfQs")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Time")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Ex_Id");

                    b.HasIndex("Crs_Id1");

                    b.ToTable("exams");
                });

            modelBuilder.Entity("CollageV2.Models.Result", b =>
                {
                    b.Property<int>("Result_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Result_Id"));

                    b.Property<int>("Ex_Id")
                        .HasColumnType("int");

                    b.Property<int>("Ex_Id1")
                        .HasColumnType("int");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<int>("S_Id")
                        .HasColumnType("int");

                    b.Property<int>("StS_Id")
                        .HasColumnType("int");

                    b.HasKey("Result_Id");

                    b.HasIndex("Ex_Id1");

                    b.HasIndex("StS_Id");

                    b.ToTable("results");
                });

            modelBuilder.Entity("CollageV2.Models.Student", b =>
                {
                    b.Property<int>("S_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("S_Id"));

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Level")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("S_FullName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("S_Id");

                    b.ToTable("students");
                });

            modelBuilder.Entity("SystemCollageV1.Models.Option", b =>
                {
                    b.Property<int>("Op_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Op_Id"));

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<string>("OpText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QIdNavigationQ_Id")
                        .HasColumnType("int");

                    b.Property<int>("Q_Id")
                        .HasColumnType("int");

                    b.HasKey("Op_Id");

                    b.HasIndex("QIdNavigationQ_Id");

                    b.ToTable("options");
                });

            modelBuilder.Entity("SystemCollageV1.Models.Question", b =>
                {
                    b.Property<int>("Q_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Q_Id"));

                    b.Property<string>("QText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Q_Id");

                    b.ToTable("question");
                });

            modelBuilder.Entity("CollageV2.Models.Exam", b =>
                {
                    b.HasOne("CollageV2.Models.Course", "Crs")
                        .WithMany("Exams")
                        .HasForeignKey("Crs_Id1");

                    b.Navigation("Crs");
                });

            modelBuilder.Entity("CollageV2.Models.Result", b =>
                {
                    b.HasOne("CollageV2.Models.Exam", "Ex")
                        .WithMany("Results")
                        .HasForeignKey("Ex_Id1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CollageV2.Models.Student", "St")
                        .WithMany()
                        .HasForeignKey("StS_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ex");

                    b.Navigation("St");
                });

            modelBuilder.Entity("SystemCollageV1.Models.Option", b =>
                {
                    b.HasOne("SystemCollageV1.Models.Question", "QIdNavigation")
                        .WithMany("Options")
                        .HasForeignKey("QIdNavigationQ_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QIdNavigation");
                });

            modelBuilder.Entity("CollageV2.Models.Course", b =>
                {
                    b.Navigation("Exams");
                });

            modelBuilder.Entity("CollageV2.Models.Exam", b =>
                {
                    b.Navigation("Results");
                });

            modelBuilder.Entity("SystemCollageV1.Models.Question", b =>
                {
                    b.Navigation("Options");
                });
#pragma warning restore 612, 618
        }
    }
}
