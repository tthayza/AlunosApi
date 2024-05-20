﻿// <auto-generated />
using AlunosApi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AlunosApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240520232004_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("AlunosApi.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Alunos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "maria@yahoo.com",
                            Idade = 24,
                            Nome = "Maria"
                        },
                        new
                        {
                            Id = 2,
                            Email = "fe@yahoo.com",
                            Idade = 20,
                            Nome = "Fernanda"
                        },
                        new
                        {
                            Id = 3,
                            Email = "camis@yahoo.com",
                            Idade = 24,
                            Nome = "Camila"
                        },
                        new
                        {
                            Id = 4,
                            Email = "iara@yahoo.com",
                            Idade = 20,
                            Nome = "Iara"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
