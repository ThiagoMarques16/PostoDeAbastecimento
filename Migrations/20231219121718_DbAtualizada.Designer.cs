﻿// <auto-generated />
using System;
using ListaDePostos.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ListaDePostos.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231219121718_DbAtualizada")]
    partial class DbAtualizada
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ListaDePostos.Models.PostoDeAbastecimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<decimal>("PrecoAlcool")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("PrecoGasolina")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.ToTable("PostosDeAbastecimento");
                });
#pragma warning restore 612, 618
        }
    }
}
