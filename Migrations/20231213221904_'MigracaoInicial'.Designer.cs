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
    [Migration("20231213221904_'MigracaoInicial'")]
    partial class MigracaoInicial
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
                        .HasColumnType("datetime");

                    b.Property<string>("Endereco")
                        .HasColumnType("longtext");

                    b.Property<string>("Gasolina")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<double>("PrecoAlcool")
                        .HasColumnType("double");

                    b.Property<double>("PrecoGasolina")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("PostosDeAbastecimento");
                });
#pragma warning restore 612, 618
        }
    }
}
