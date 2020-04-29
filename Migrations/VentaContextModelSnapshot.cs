﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoSoftware;

namespace ProyectoSoftware.Migrations
{
    [DbContext(typeof(VentaContext))]
    partial class VentaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProyectoSoftware.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dni")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fechadeactualizaion1")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ProyectoSoftware.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fechadeactualizaion1")
                        .HasColumnType("datetime2");

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("ProyectoSoftware.Venta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClienteNavigatorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fechadeactualizaion1")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fechadeactualizaion2")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id1")
                        .HasColumnType("int");

                    b.Property<int?>("ProductoNavigatorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteNavigatorId");

                    b.HasIndex("ProductoNavigatorId");

                    b.ToTable("Venta");
                });

            modelBuilder.Entity("ProyectoSoftware.Venta", b =>
                {
                    b.HasOne("ProyectoSoftware.Cliente", "ClienteNavigator")
                        .WithMany()
                        .HasForeignKey("ClienteNavigatorId");

                    b.HasOne("ProyectoSoftware.Producto", "ProductoNavigator")
                        .WithMany()
                        .HasForeignKey("ProductoNavigatorId");
                });
#pragma warning restore 612, 618
        }
    }
}
