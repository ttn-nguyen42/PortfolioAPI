﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Portfolio.Contexts;

#nullable disable

namespace Portfolio.Migrations.Key
{
    [DbContext(typeof(KeyContext))]
    partial class KeyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Portfolio.Entities.Key", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Authorization")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Keys");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Authorization = 0,
                            Value = "iD2e/0oQtUFkAz4omzjZ8g=="
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
