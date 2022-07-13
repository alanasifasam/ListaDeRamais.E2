using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ListaDeRamais.E2.Models
{
    public partial class Banco_ramal2Context : DbContext
    {
        public Banco_ramal2Context()
        {
        }

        public Banco_ramal2Context(DbContextOptions<Banco_ramal2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Departamento> Departamentos { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<FunRamais> FunRamais { get; set; }
        public virtual DbSet<Funcionario> Funcionarios { get; set; }
        public virtual DbSet<Ramais> Ramais { get; set; }
        public virtual DbSet<Telefone> Telefones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=TI-051570-ALANA\\SQLEXPRESS;Database=banco_ramal2;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.CodigoDepId)
                    .HasName("PK__departam__4A80D52132E81028");

                entity.ToTable("departamento");

                entity.Property(e => e.CodigoDepId).HasColumnName("codigo_dep_id");

                entity.Property(e => e.CodigoEmpFk).HasColumnName("codigo_emp_FK");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoEmpFkNavigation)
                    .WithMany(p => p.Departamentos)
                    .HasForeignKey(d => d.CodigoEmpFk)
                    .HasConstraintName("FK_empresa_dep");

              
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.CodigoEmpId)
                    .HasName("PK__empresa__06E01EEBD776268B");

                entity.ToTable("empresa");

                entity.Property(e => e.CodigoEmpId).HasColumnName("codigo_emp_id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<FunRamais>(entity =>
            {
                entity.ToTable("fun_ramais");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CodigoFunFk).HasColumnName("codigo_fun_FK");

                entity.Property(e => e.CodigoRamalFk).HasColumnName("codigo_ramal_FK");

                entity.HasOne(d => d.CodigoFunFkNavigation)
                    .WithMany(p => p.FunRamais)
                    .HasForeignKey(d => d.CodigoFunFk)
                    .HasConstraintName("fk_fun_ramal");

                entity.HasOne(d => d.CodigoRamalFkNavigation)
                    .WithMany(p => p.FunRamais)
                    .HasForeignKey(d => d.CodigoRamalFk)
                    .HasConstraintName("fk_ramal_fun");
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.HasKey(e => e.CodigoFunId)
                    .HasName("PK__funciona__11EC4FC4F4B61F7A");

                entity.ToTable("funcionario");

                entity.Property(e => e.CodigoFunId).HasColumnName("codigo_fun_id");

                entity.Property(e => e.Cargo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("cargo");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Sobrenome)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sobrenome");
            });

            modelBuilder.Entity<Ramais>(entity =>
            {
                entity.HasKey(e => e.CodigoRamalId)
                    .HasName("PK__ramais__16F01D351FA7E035");

                entity.ToTable("ramais");

                entity.Property(e => e.CodigoRamalId).HasColumnName("codigo_ramal_id");

                entity.Property(e => e.CodigoDepFk).HasColumnName("codigo_dep_FK");

                entity.Property(e => e.HostIp).HasColumnName("host_ip");

                entity.Property(e => e.NumeroRamal).HasColumnName("numero_ramal");

                entity.Property(e => e.Senha)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.CodigoDepFkNavigation)
                    .WithMany(p => p.Ramais)
                    .HasForeignKey(d => d.CodigoDepFk)
                    .HasConstraintName("FK_DEP_RAMAIS");
                
            });

            modelBuilder.Entity<Telefone>(entity =>
            {
                entity.HasKey(e => e.CodigoId)
                    .HasName("PK__telefone__75B12964F04ABC52");

                entity.ToTable("telefone");

                entity.Property(e => e.CodigoId).HasColumnName("codigo_id");

                entity.Property(e => e.CodigoFunFk).HasColumnName("codigo_fun_Fk");

                entity.Property(e => e.NumeroTelefone)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("numero_telefone");

               

                entity.HasOne(d => d.CodigoFunFkNavigation)
                    .WithMany(p => p.Telefones)
                    .HasForeignKey(d => d.CodigoFunFk)
                    .HasConstraintName("fk_telefone");

            });

         
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
