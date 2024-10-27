using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Proyecto_final.Models;

public partial class Practica1Context : DbContext
{
    public Practica1Context()
    {
    }

    public Practica1Context(DbContextOptions<Practica1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<CursosUmg> CursosUmgs { get; set; }

    public virtual DbSet<EstudiantesUmg> EstudiantesUmgs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CursosUmg>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CursosUM__3214EC278988B199");

            entity.ToTable("CursosUMG");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Curos)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Semestre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EstudiantesUmg>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Estudian__3214EC27DF8AED07");

            entity.ToTable("EstudiantesUMG");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
