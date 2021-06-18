﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VendasWebMvc.Data;

namespace VendasWebMvc.Migrations
{
    [DbContext(typeof(VendasWebMvcContext))]
    partial class VendasWebMvcContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("VendasWebMvc.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("VendasWebMvc.Models.RecordVendas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Data");

                    b.Property<double>("Quant");

                    b.Property<int>("Status");

                    b.Property<int?>("VendedorId");

                    b.HasKey("Id");

                    b.HasIndex("VendedorId");

                    b.ToTable("RecordVendas");
                });

            modelBuilder.Entity("VendasWebMvc.Models.Vendedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataNasc");

                    b.Property<int?>("DepartmentId");

                    b.Property<string>("Email");

                    b.Property<string>("Nome");

                    b.Property<double>("SalarioBase");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Vendedor");
                });

            modelBuilder.Entity("VendasWebMvc.Models.RecordVendas", b =>
                {
                    b.HasOne("VendasWebMvc.Models.Vendedor", "Vendedor")
                        .WithMany("Vendas")
                        .HasForeignKey("VendedorId");
                });

            modelBuilder.Entity("VendasWebMvc.Models.Vendedor", b =>
                {
                    b.HasOne("VendasWebMvc.Models.Department", "Department")
                        .WithMany("Vendedores")
                        .HasForeignKey("DepartmentId");
                });
#pragma warning restore 612, 618
        }
    }
}
