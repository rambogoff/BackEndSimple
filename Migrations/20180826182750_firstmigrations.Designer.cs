﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using react_backend;

namespace react.Migrations
{
    [DbContext(typeof(LinkedinContext))]
    [Migration("20180826182750_firstmigrations")]
    partial class firstmigrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("react.Models.Activities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EducationId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("EducationId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("react.Models.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Degree");

                    b.Property<int>("EndYear");

                    b.Property<string>("Name");

                    b.Property<int>("StartingYear");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Education");
                });

            modelBuilder.Entity("react.Models.Experience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName");

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Location");

                    b.Property<string>("Position");

                    b.Property<DateTime>("StartingDate");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Experience");
                });

            modelBuilder.Entity("react.Models.Honor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Details");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Honors");
                });

            modelBuilder.Entity("react.Models.Languages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Language");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("react.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("react.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Mail");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("SurName");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("react.Models.Activities", b =>
                {
                    b.HasOne("react.Models.Education", "Education")
                        .WithMany("Activities")
                        .HasForeignKey("EducationId");
                });

            modelBuilder.Entity("react.Models.Education", b =>
                {
                    b.HasOne("react.Models.User", "User")
                        .WithMany("Educations")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("react.Models.Experience", b =>
                {
                    b.HasOne("react.Models.User", "User")
                        .WithMany("Experiencies")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("react.Models.Honor", b =>
                {
                    b.HasOne("react.Models.User", "User")
                        .WithMany("Honors")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("react.Models.Languages", b =>
                {
                    b.HasOne("react.Models.User", "User")
                        .WithMany("Languages")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("react.Models.Skill", b =>
                {
                    b.HasOne("react.Models.User", "User")
                        .WithMany("Skills")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}