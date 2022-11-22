﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectTracker.Models;

namespace ProjectTracker.Migrations
{
    [DbContext(typeof(ProjectTrackerContext))]
    [Migration("20200327165016_ProjectModelChanges")]
    partial class ProjectModelChanges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectTracker.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProjectTypes");
                });

            modelBuilder.Entity("ProjectTracker.Models.Tracker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("Count")
                        .HasColumnType("tinyint");

                    b.Property<int?>("ProjectTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectTypeId");

                    b.ToTable("Trackers");
                });

            modelBuilder.Entity("ProjectTracker.Models.Tracker", b =>
                {
                    b.HasOne("ProjectTracker.Models.Project", "ProjectType")
                        .WithMany()
                        .HasForeignKey("ProjectTypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
