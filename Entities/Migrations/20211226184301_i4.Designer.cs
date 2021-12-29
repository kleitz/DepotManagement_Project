﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Entities.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211226184301_i4")]
    partial class i4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DepotManagement.Models.Customers", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MobileNumber")
                        .HasColumnType("int");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("DepotManagement.Models.InBoundOrders", b =>
                {
                    b.Property<int>("InOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OrderStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("InOrderId");

                    b.ToTable("InBoundOrders");
                });

            modelBuilder.Entity("DepotManagement.Models.OutBoundOrders", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<double>("OrderAmount")
                        .HasColumnType("float");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("OutBoundOrders");
                });

            modelBuilder.Entity("DepotManagement.Models.Shipment", b =>
                {
                    b.Property<int>("ShipmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DriverName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ShipmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ShipmentStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TruckNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ShipmentId");

                    b.HasIndex("OrderId");

                    b.ToTable("Shipments");
                });

            modelBuilder.Entity("SystemManagementService.Models.LPN", b =>
                {
                    b.Property<int>("LPNID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NodeId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LPNID");

                    b.HasIndex("NodeId");

                    b.ToTable("LPN");
                });

            modelBuilder.Entity("SystemManagementService.Models.NodeEdges", b =>
                {
                    b.Property<int>("EdgeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EdgeLength")
                        .HasColumnType("int");

                    b.Property<string>("EndNode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartNode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EdgeId");

                    b.ToTable("NodeEdges");
                });

            modelBuilder.Entity("SystemManagementService.Models.Nodes", b =>
                {
                    b.Property<string>("NodeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NodeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NodeType")
                        .HasColumnType("int");

                    b.Property<string>("Zone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NodeId");

                    b.ToTable("Nodes");
                });

            modelBuilder.Entity("SystemManagementService.Models.ProductBundles", b =>
                {
                    b.Property<int>("BundleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LPNID")
                        .HasColumnType("int");

                    b.Property<string>("LotCode")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("BundleID");

                    b.HasIndex("LPNID");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductBundles");
                });

            modelBuilder.Entity("SystemManagementService.Models.Products", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProductDescription")
                        .HasColumnType("varchar(80)");

                    b.Property<string>("ProductNumber")
                        .HasColumnType("varchar(50)");

                    b.Property<double>("ProductPrice")
                        .HasColumnType("float");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DepotManagement.Models.OutBoundOrders", b =>
                {
                    b.HasOne("DepotManagement.Models.Customers", "Customers")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customers");
                });

            modelBuilder.Entity("DepotManagement.Models.Shipment", b =>
                {
                    b.HasOne("DepotManagement.Models.OutBoundOrders", "OutBoundOrders")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OutBoundOrders");
                });

            modelBuilder.Entity("SystemManagementService.Models.LPN", b =>
                {
                    b.HasOne("SystemManagementService.Models.Nodes", "Nodes")
                        .WithMany()
                        .HasForeignKey("NodeId");

                    b.Navigation("Nodes");
                });

            modelBuilder.Entity("SystemManagementService.Models.ProductBundles", b =>
                {
                    b.HasOne("SystemManagementService.Models.LPN", "LPN")
                        .WithMany("ProductBundle")
                        .HasForeignKey("LPNID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SystemManagementService.Models.Products", "Products")
                        .WithMany("ProductBundle")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LPN");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("SystemManagementService.Models.LPN", b =>
                {
                    b.Navigation("ProductBundle");
                });

            modelBuilder.Entity("SystemManagementService.Models.Products", b =>
                {
                    b.Navigation("ProductBundle");
                });
#pragma warning restore 612, 618
        }
    }
}
