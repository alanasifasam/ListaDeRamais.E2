﻿// <auto-generated />
using System;
using ListaDeRamais.E2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ListaDeRamais.E2.Migrations
{
    [DbContext(typeof(Banco_ramal2Context))]
    partial class Banco_ramal2ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:Collation", "Latin1_General_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("ListaDeRamais.E2.Models.Departamento", b =>
                {
                    b.Property<int>("CodigoDepId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("codigo_dep_id")
                        .UseIdentityColumn();

                    b.Property<int?>("CodigoEmpFk")
                        .HasColumnType("int")
                        .HasColumnName("codigo_emp_FK");

                    b.Property<string>("Nome")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("CodigoDepId")
                        .HasName("PK__departam__4A80D52132E81028");

                    b.HasIndex("CodigoEmpFk");

                    b.ToTable("departamento");
                });

            modelBuilder.Entity("ListaDeRamais.E2.Models.Empresa", b =>
                {
                    b.Property<int>("CodigoEmpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("codigo_emp_id")
                        .UseIdentityColumn();

                    b.Property<string>("Nome")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nome");

                    b.HasKey("CodigoEmpId")
                        .HasName("PK__empresa__06E01EEBD776268B");

                    b.ToTable("empresa");
                });

            modelBuilder.Entity("ListaDeRamais.E2.Models.FunRamais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .UseIdentityColumn();

                    b.Property<int?>("CodigoFunFk")
                        .HasColumnType("int")
                        .HasColumnName("codigo_fun_FK");

                    b.Property<int?>("CodigoRamalFk")
                        .HasColumnType("int")
                        .HasColumnName("codigo_ramal_FK");

                    b.HasKey("Id");

                    b.HasIndex("CodigoFunFk");

                    b.HasIndex("CodigoRamalFk");

                    b.ToTable("fun_ramais");
                });

            modelBuilder.Entity("ListaDeRamais.E2.Models.Funcionario", b =>
                {
                    b.Property<int>("CodigoFunId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("codigo_fun_id")
                        .UseIdentityColumn();

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("cargo");

                    b.Property<int?>("CodigoFunFk")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nome");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("sobrenome");

                    b.HasKey("CodigoFunId")
                        .HasName("PK__funciona__11EC4FC4F4B61F7A");

                    b.ToTable("funcionario");
                });

            modelBuilder.Entity("ListaDeRamais.E2.Models.Ramais", b =>
                {
                    b.Property<int>("CodigoRamalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("codigo_ramal_id")
                        .UseIdentityColumn();

                    b.Property<int?>("CodigoDepFk")
                        .HasColumnType("int")
                        .HasColumnName("codigo_dep_FK");

                    b.Property<int>("CodigoDepId")
                        .HasColumnType("int");

                    b.Property<int?>("DepartamentoCodigoDepId")
                        .HasColumnType("int");

                    b.Property<int?>("HostIp")
                        .HasColumnType("int")
                        .HasColumnName("host_ip");

                    b.Property<int?>("NumeroRamal")
                        .HasColumnType("int")
                        .HasColumnName("numero_ramal");

                    b.Property<string>("Senha")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("senha");

                    b.HasKey("CodigoRamalId")
                        .HasName("PK__ramais__16F01D351FA7E035");

                    b.HasIndex("CodigoDepFk");

                    b.HasIndex("DepartamentoCodigoDepId");

                    b.ToTable("ramais");
                });

            modelBuilder.Entity("ListaDeRamais.E2.Models.Telefone", b =>
                {
                    b.Property<int>("CodigoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("codigo_id")
                        .UseIdentityColumn();

                    b.Property<int?>("CodigoFunFk")
                        .HasColumnType("int")
                        .HasColumnName("codigo_fun_Fk");

                    b.Property<string>("NumeroTelefone")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("numero_telefone");

                    b.HasKey("CodigoId")
                        .HasName("PK__telefone__75B12964F04ABC52");

                    b.HasIndex("CodigoFunFk");

                    b.ToTable("telefone");
                });

            modelBuilder.Entity("ListaDeRamais.E2.Models.Departamento", b =>
                {
                    b.HasOne("ListaDeRamais.E2.Models.Empresa", "CodigoEmpFkNavigation")
                        .WithMany("Departamentos")
                        .HasForeignKey("CodigoEmpFk")
                        .HasConstraintName("FK_empresa_dep");

                    b.Navigation("CodigoEmpFkNavigation");
                });

            modelBuilder.Entity("ListaDeRamais.E2.Models.FunRamais", b =>
                {
                    b.HasOne("ListaDeRamais.E2.Models.Funcionario", "CodigoFunFkNavigation")
                        .WithMany("FunRamais")
                        .HasForeignKey("CodigoFunFk")
                        .HasConstraintName("fk_fun_ramal");

                    b.HasOne("ListaDeRamais.E2.Models.Ramais", "CodigoRamalFkNavigation")
                        .WithMany("FunRamais")
                        .HasForeignKey("CodigoRamalFk")
                        .HasConstraintName("fk_ramal_fun");

                    b.Navigation("CodigoFunFkNavigation");

                    b.Navigation("CodigoRamalFkNavigation");
                });

            modelBuilder.Entity("ListaDeRamais.E2.Models.Ramais", b =>
                {
                    b.HasOne("ListaDeRamais.E2.Models.Departamento", "CodigoDepFkNavigation")
                        .WithMany("Ramais")
                        .HasForeignKey("CodigoDepFk")
                        .HasConstraintName("FK_DEP_RAMAIS");

                    b.HasOne("ListaDeRamais.E2.Models.Departamento", "Departamento")
                        .WithMany()
                        .HasForeignKey("DepartamentoCodigoDepId");

                    b.Navigation("CodigoDepFkNavigation");

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("ListaDeRamais.E2.Models.Telefone", b =>
                {
                    b.HasOne("ListaDeRamais.E2.Models.Funcionario", "CodigoFunFkNavigation")
                        .WithMany("Telefones")
                        .HasForeignKey("CodigoFunFk")
                        .HasConstraintName("fk_telefone");

                    b.Navigation("CodigoFunFkNavigation");
                });

            modelBuilder.Entity("ListaDeRamais.E2.Models.Departamento", b =>
                {
                    b.Navigation("Ramais");
                });

            modelBuilder.Entity("ListaDeRamais.E2.Models.Empresa", b =>
                {
                    b.Navigation("Departamentos");
                });

            modelBuilder.Entity("ListaDeRamais.E2.Models.Funcionario", b =>
                {
                    b.Navigation("FunRamais");

                    b.Navigation("Telefones");
                });

            modelBuilder.Entity("ListaDeRamais.E2.Models.Ramais", b =>
                {
                    b.Navigation("FunRamais");
                });
#pragma warning restore 612, 618
        }
    }
}
