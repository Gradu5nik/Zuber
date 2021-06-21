﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Zuber.Models;

namespace Zuber.Migrations
{
    [DbContext(typeof(ZuberDBContext))]
    partial class ZuberDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Zuber.Models.Dot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Hidden")
                        .HasColumnType("bit");

                    b.Property<double>("Lat")
                        .HasColumnType("float");

                    b.Property<double>("Long")
                        .HasColumnType("float");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<int>("ZuberUserID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ZuberUserID");

                    b.ToTable("Dots");
                });

            modelBuilder.Entity("Zuber.Models.Invite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RideID")
                        .HasColumnType("int");

                    b.Property<int>("ZuberUserID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RideID");

                    b.HasIndex("ZuberUserID");

                    b.ToTable("Invites");
                });

            modelBuilder.Entity("Zuber.Models.Passenger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RideID")
                        .HasColumnType("int");

                    b.Property<int?>("ZuberUserID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RideID");

                    b.HasIndex("ZuberUserID");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("Zuber.Models.Ride", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CarDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<int>("PlacesRemaining")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Rides");
                });

            modelBuilder.Entity("Zuber.Models.ZuberUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DotId")
                        .HasColumnType("int");

                    b.Property<bool>("Driver")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RideId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RideId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Zuber.Models.Dot", b =>
                {
                    b.HasOne("Zuber.Models.ZuberUser", "ZuberUser")
                        .WithMany()
                        .HasForeignKey("ZuberUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ZuberUser");
                });

            modelBuilder.Entity("Zuber.Models.Invite", b =>
                {
                    b.HasOne("Zuber.Models.Ride", "Ride")
                        .WithMany()
                        .HasForeignKey("RideID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Zuber.Models.ZuberUser", "ZuberUser")
                        .WithMany()
                        .HasForeignKey("ZuberUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ride");

                    b.Navigation("ZuberUser");
                });

            modelBuilder.Entity("Zuber.Models.Passenger", b =>
                {
                    b.HasOne("Zuber.Models.Ride", "Ride")
                        .WithMany()
                        .HasForeignKey("RideID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Zuber.Models.ZuberUser", "ZuberUser")
                        .WithMany()
                        .HasForeignKey("ZuberUserID");

                    b.Navigation("Ride");

                    b.Navigation("ZuberUser");
                });

            modelBuilder.Entity("Zuber.Models.ZuberUser", b =>
                {
                    b.HasOne("Zuber.Models.Ride", "Ride")
                        .WithMany()
                        .HasForeignKey("RideId");

                    b.Navigation("Ride");
                });
#pragma warning restore 612, 618
        }
    }
}
