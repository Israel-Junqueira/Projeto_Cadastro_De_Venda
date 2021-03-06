// <auto-generated />
using System;
using CadastroDeVendas.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CadastroDeVendas.Migrations
{
    [DbContext(typeof(CadastroDeVendasContext))]
    [Migration("20220316140559_DepartmentForeignkey")]
    partial class DepartmentForeignkey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CadastroDeVendas.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("CadastroDeVendas.Models.SalesRecord", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<int?>("SellerId");

                    b.Property<double>("amount");

                    b.Property<int>("status");

                    b.HasKey("ID");

                    b.HasIndex("SellerId");

                    b.ToTable("SalesRecords");
                });

            modelBuilder.Entity("CadastroDeVendas.Models.Seller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("BaseSalary");

                    b.Property<DateTime>("BirthData");

                    b.Property<int>("DepartmentId");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Sellers");
                });

            modelBuilder.Entity("CadastroDeVendas.Models.SalesRecord", b =>
                {
                    b.HasOne("CadastroDeVendas.Models.Seller", "Seller")
                        .WithMany("records")
                        .HasForeignKey("SellerId");
                });

            modelBuilder.Entity("CadastroDeVendas.Models.Seller", b =>
                {
                    b.HasOne("CadastroDeVendas.Models.Department", "Department")
                        .WithMany("sellers")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
