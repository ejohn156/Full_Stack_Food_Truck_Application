﻿// <auto-generated />
using System;
using Full_Stack_Food_Truck_Application.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Full_Stack_Food_Truck_Application.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200505202508_setting_up_coordinates0")]
    partial class setting_up_coordinates0
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Full_Stack_Food_Truck_Application.Data.Entities.Coordinates", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<float>("Latitude")
                        .HasColumnType("real");

                    b.Property<float>("Longitude")
                        .HasColumnType("real");

                    b.Property<string>("Truck_Id")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Coordinates");
                });

            modelBuilder.Entity("Full_Stack_Food_Truck_Application.Data.Entities.Favorite", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string[]>("Categories")
                        .HasColumnType("text[]");

                    b.Property<string>("Coordinate_Id")
                        .HasColumnType("text");

                    b.Property<string>("Creator_Id")
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<string>("Phone_Number")
                        .HasColumnType("text");

                    b.Property<string>("Price")
                        .HasColumnType("text");

                    b.Property<decimal>("Rating")
                        .HasColumnType("numeric");

                    b.Property<string>("Truck_Id")
                        .HasColumnType("text");

                    b.Property<string>("Truck_Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Coordinate_Id");

                    b.HasIndex("Creator_Id");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("Full_Stack_Food_Truck_Application.Data.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("First_Name")
                        .HasColumnType("text");

                    b.Property<string>("Last_Name")
                        .HasColumnType("text");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Full_Stack_Food_Truck_Application.Data.Entities.Favorite", b =>
                {
                    b.HasOne("Full_Stack_Food_Truck_Application.Data.Entities.Coordinates", "Coordinates")
                        .WithMany()
                        .HasForeignKey("Coordinate_Id");

                    b.HasOne("Full_Stack_Food_Truck_Application.Data.Entities.User", "CreatedBy")
                        .WithMany("Favorites")
                        .HasForeignKey("Creator_Id");
                });
#pragma warning restore 612, 618
        }
    }
}
