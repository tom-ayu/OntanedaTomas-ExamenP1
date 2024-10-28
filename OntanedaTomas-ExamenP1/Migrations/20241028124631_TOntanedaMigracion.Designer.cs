﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace OntanedaTomas_ExamenP1.Migrations
{
    [DbContext(typeof(TOntanedaContext))]
    [Migration("20241028124631_TOntanedaMigracion")]
    partial class TOntanedaMigracion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OntanedaTomas_ExamenP1.Models.Celular", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Anio")
                        .HasColumnType("int");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<float>("Precio")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Celular");
                });

            modelBuilder.Entity("OntanedaTomas_ExamenP1.Models.TOntaneda", b =>
                {
                    b.Property<int>("IdCPU")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCPU"));

                    b.Property<bool>("EstaOverclokeado")
                        .HasColumnType("bit");

                    b.Property<DateOnly>("FechaObtencion")
                        .HasColumnType("date");

                    b.Property<int>("IdCelular")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<float>("VelocidadCPU")
                        .HasColumnType("real");

                    b.HasKey("IdCPU");

                    b.HasIndex("IdCelular");

                    b.ToTable("TOntaneda");
                });

            modelBuilder.Entity("OntanedaTomas_ExamenP1.Models.TOntaneda", b =>
                {
                    b.HasOne("OntanedaTomas_ExamenP1.Models.Celular", "Celular")
                        .WithMany()
                        .HasForeignKey("IdCelular")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Celular");
                });
#pragma warning restore 612, 618
        }
    }
}
