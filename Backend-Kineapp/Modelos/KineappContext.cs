using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend_Kineapp.Modelos;

public partial class KineappContext : DbContext
{
    public KineappContext()
    {
        
    }

    public KineappContext(DbContextOptions<KineappContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DetalleTurno> DetalleTurnos { get; set; }

    public virtual DbSet<HistorialMedico> HistorialMedicos { get; set; }

    public virtual DbSet<Kinesiologo1> Kinesiologo1s { get; set; }

    public virtual DbSet<MedioPago> MedioPagos { get; set; }

    public virtual DbSet<ObraSocial> ObraSocials { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<TipoTratamiento> TipoTratamientos { get; set; }

    public virtual DbSet<Tratamiento> Tratamientos { get; set; }

    public virtual DbSet<Turno> Turnos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-NR6LRSF\\SQLEXPRESS; Database=Kineapp; User=usuarioSQL; Password=Valen2003; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DetalleTurno>(entity =>
        {
            entity.HasKey(e => e.IdDetalle);

            entity.ToTable("Detalle_turno");

            entity.Property(e => e.IdDetalle)
                .ValueGeneratedNever()
                .HasColumnName("Id_detalle");
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.HoraInicio).HasPrecision(0);
            entity.Property(e => e.IdKinesiologo).HasColumnName("id_kinesiologo");
            entity.Property(e => e.IdMedioPago).HasColumnName("id_medio_pago");
            entity.Property(e => e.IdObraSocial).HasColumnName("id_obra_social");
            entity.Property(e => e.IdTratamiento).HasColumnName("id_tratamiento");

            entity.HasOne(d => d.IdKinesiologoNavigation).WithMany(p => p.DetalleTurnos)
                .HasForeignKey(d => d.IdKinesiologo)
                .HasConstraintName("FK_Detalle_turno_Kinesiologo1");

            entity.HasOne(d => d.IdMedioPagoNavigation).WithMany(p => p.DetalleTurnos)
                .HasForeignKey(d => d.IdMedioPago)
                .HasConstraintName("FK_Detalle_turno_Medio_pago");

            entity.HasOne(d => d.IdObraSocialNavigation).WithMany(p => p.DetalleTurnos)
                .HasForeignKey(d => d.IdObraSocial)
                .HasConstraintName("FK_Detalle_turno_Obra_social");

            entity.HasOne(d => d.IdTratamientoNavigation).WithMany(p => p.DetalleTurnos)
                .HasForeignKey(d => d.IdTratamiento)
                .HasConstraintName("FK_Detalle_turno_Tratamiento");
        });

        modelBuilder.Entity<HistorialMedico>(entity =>
        {
            entity.HasKey(e => e.IdHistorial);

            entity.ToTable("Historial_medico");

            entity.Property(e => e.IdHistorial)
                .ValueGeneratedNever()
                .HasColumnName("Id_historial");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("date")
                .HasColumnName("Fecha_creacion");
            entity.Property(e => e.Nota)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Kinesiologo1>(entity =>
        {
            entity.HasKey(e => e.IdKinesiologo);

            entity.ToTable("Kinesiologo1");

            entity.Property(e => e.IdKinesiologo).HasColumnName("Id_kinesiologo");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Dni).HasColumnName("DNI");
            entity.Property(e => e.Emal)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Kinesiologo1s)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_Kinesiologo1_Usuario");
        });

        modelBuilder.Entity<MedioPago>(entity =>
        {
            entity.HasKey(e => e.IdMedio);

            entity.ToTable("Medio_pago");

            entity.Property(e => e.IdMedio).HasColumnName("Id_medio");
            entity.Property(e => e.IdDetalleTurno).HasColumnName("id_detalle_turno");
            entity.Property(e => e.TipoMedioPago).HasColumnName("tipo_medio_pago");
        });

        modelBuilder.Entity<ObraSocial>(entity =>
        {
            entity.HasKey(e => e.IdObra);

            entity.ToTable("Obra_social");

            entity.Property(e => e.IdObra).HasColumnName("Id_obra");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.IdPaciente);

            entity.ToTable("Paciente");

            entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");
            entity.Property(e => e.Antecedentes)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Dni).HasColumnName("DNI");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaNacimento).HasColumnType("date");
            entity.Property(e => e.IdHistorial).HasColumnName("Id_historial");
            entity.Property(e => e.IdObraSocial).HasColumnName("Id_obraSocial");
            entity.Property(e => e.IdTurno).HasColumnName("Id_turno");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(80)
                .IsUnicode(false);

            entity.HasOne(d => d.IdHistorialNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdHistorial)
                .HasConstraintName("FK_Paciente_Historial_medico");

            entity.HasOne(d => d.IdObraSocialNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdObraSocial)
                .HasConstraintName("FK_Paciente_Obra_social1");

            entity.HasOne(d => d.IdTurnoNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdTurno)
                .HasConstraintName("FK_Paciente_Turno");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Pacientes)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_Paciente_Usuario");
        });

        modelBuilder.Entity<TipoTratamiento>(entity =>
        {
            entity.HasKey(e => e.IdTipoTratamiento);

            entity.ToTable("Tipo_tratamiento");

            entity.Property(e => e.IdTipoTratamiento).HasColumnName("Id_tipo_tratamiento");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tratamiento>(entity =>
        {
            entity.HasKey(e => e.IdTratamiento);

            entity.ToTable("Tratamiento");

            entity.Property(e => e.IdTratamiento).HasColumnName("Id_tratamiento");
            entity.Property(e => e.Comentario)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaFin)
                .HasColumnType("date")
                .HasColumnName("Fecha_fin");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("date")
                .HasColumnName("Fecha_inicio");
            entity.Property(e => e.IdTipoTratamiento).HasColumnName("id_tipo_tratamiento");
            entity.Property(e => e.Objetivo)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTipoTratamientoNavigation).WithMany(p => p.Tratamientos)
                .HasForeignKey(d => d.IdTipoTratamiento)
                .HasConstraintName("FK_Tratamiento_Tipo_tratamiento");
        });

        modelBuilder.Entity<Turno>(entity =>
        {
            entity.HasKey(e => e.IdTurno);

            entity.ToTable("Turno");

            entity.Property(e => e.IdTurno).HasColumnName("Id_Turno");
            entity.Property(e => e.IdDetalleTurno).HasColumnName("id_detalle_turno");
            entity.Property(e => e.Nota)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");
            entity.Property(e => e.IdKinesiologo).HasColumnName("id_kinesiologo");
            entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");
            //entity.Property(e => e.TipoUsuario).HasColumnName("Tipo_usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
