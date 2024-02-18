using System;
using System.Collections.Generic;
using ETG.Prueba.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ETG.Prueba.Infraestructure.Data
{
    public partial class ETG_DBContext : DbContext
    {
        public ETG_DBContext()
        {
        }

        public ETG_DBContext(DbContextOptions<ETG_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Usuarios> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ETG_DB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.PedId)
                    .HasName("PK__PEDIDO__50CF4A258A013A96");

                entity.ToTable("PEDIDO", "dev");

                entity.Property(e => e.PedId).HasColumnName("PedID");

                entity.Property(e => e.PedIva).HasColumnName("PedIVA");

                entity.Property(e => e.PedSubTot).HasColumnType("money");

                entity.Property(e => e.PedTotal).HasColumnType("money");

                entity.Property(e => e.PedVrUnit).HasColumnType("money");

                entity.HasOne(d => d.PedProdNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.PedProd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PEDIDO__PedProd__2B3F6F97");

                entity.HasOne(d => d.PedUsuNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.PedUsu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PEDIDO__PedUsu__2A4B4B5E");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.ProId)
                    .HasName("PK__PRODUCTO__620295F0C6A0DBE3");

                entity.ToTable("PRODUCTO", "dev");

                entity.Property(e => e.ProId).HasColumnName("ProID");

                entity.Property(e => e.ProDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProValor).HasColumnType("money");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.UsuId)
                    .HasName("PK__USUARIOS__685263A30005A695");

                entity.ToTable("USUARIOS", "dev");

                entity.Property(e => e.UsuId).HasColumnName("UsuID");

                entity.Property(e => e.UsuNombre).HasDefaultValueSql("(NEXT VALUE FOR [dev].[AutoNum])");

                entity.Property(e => e.UsuPass)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.HasSequence<int>("AutoNum", "dev");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
