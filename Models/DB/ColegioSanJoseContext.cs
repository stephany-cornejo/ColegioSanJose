using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SanJoseEstudiantes.Models.DB;

public partial class ColegioSanJoseContext : DbContext
{
    public ColegioSanJoseContext()
    {
    }

    public ColegioSanJoseContext(DbContextOptions<ColegioSanJoseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<Expediente> Expedientes { get; set; }

    public virtual DbSet<Materium> Materia { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database=ColegioSanJose; TrustServerCertificate=True; Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.AlumnoId).HasName("PK__ALumno__90A6AA135DFE2C43");

            entity.ToTable("ALumno");

            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Grado)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Expediente>(entity =>
        {
            entity.HasKey(e => e.ExtpedienteId).HasName("PK__Expedien__9C3D3FB0AF769829");

            entity.ToTable("Expediente");

            entity.Property(e => e.NotaFinal).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Alumno).WithMany(p => p.Expedientes)
                .HasForeignKey(d => d.AlumnoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Expedient__Alumn__3B75D760");

            entity.HasOne(d => d.Materia).WithMany(p => p.Expedientes)
                .HasForeignKey(d => d.MateriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Expedient__Mater__3C69FB99");
        });

        modelBuilder.Entity<Materium>(entity =>
        {
            entity.HasKey(e => e.MateriaId).HasName("PK__Materia__0D019DE1BC715C3E");

            // Ensure the C# class maps to the actual table name in the database
            entity.ToTable("Materia");

            entity.Property(e => e.Docente)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NombreMateria)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
