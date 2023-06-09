﻿// <auto-generated />
using System;
using Backend_Kineapp.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend_Kineapp.Migrations
{
    [DbContext(typeof(KineappContext))]
    [Migration("20230428135134_TurnoDetalleTurno")]
    partial class TurnoDetalleTurno
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Backend_Kineapp.Modelos.DetalleTurno", b =>
                {
                    b.Property<int>("IdDetalle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_detalle");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDetalle"));

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("date");

                    b.Property<TimeSpan?>("HoraFin")
                        .HasColumnType("time");

                    b.Property<TimeSpan?>("HoraInicio")
                        .HasPrecision(0)
                        .HasColumnType("time(0)");

                    b.Property<int?>("IdKinesiologo")
                        .HasColumnType("int")
                        .HasColumnName("id_kinesiologo");

                    b.Property<int?>("IdMedioPago")
                        .HasColumnType("int")
                        .HasColumnName("id_medio_pago");

                    b.Property<int?>("IdObraSocial")
                        .HasColumnType("int")
                        .HasColumnName("id_obra_social");

                    b.Property<int?>("IdTratamiento")
                        .HasColumnType("int")
                        .HasColumnName("id_tratamiento");

                    b.HasKey("IdDetalle");

                    b.HasIndex("IdKinesiologo");

                    b.HasIndex("IdMedioPago");

                    b.HasIndex("IdObraSocial");

                    b.HasIndex("IdTratamiento");

                    b.ToTable("Detalle_turno", (string)null);
                });

            modelBuilder.Entity("Backend_Kineapp.Modelos.HistorialMedico", b =>
                {
                    b.Property<int>("IdHistorial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdHistorial");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdHistorial"));

                    b.Property<string>("Descripcion")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("date")
                        .HasColumnName("FechaCreacion");

                    b.Property<string>("Nota")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("IdHistorial");

                    b.ToTable("HistorialMedico", (string)null);
                });

            modelBuilder.Entity("Backend_Kineapp.Modelos.Kinesiologo1", b =>
                {
                    b.Property<int>("IdKinesiologo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_kinesiologo");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdKinesiologo"));

                    b.Property<string>("Apellido")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<long?>("Dni")
                        .HasColumnType("bigint")
                        .HasColumnName("DNI");

                    b.Property<string>("Emal")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("IdUsuario")
                        .HasColumnType("int")
                        .HasColumnName("Id_usuario");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telefono")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdKinesiologo");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Kinesiologo1", (string)null);
                });

            modelBuilder.Entity("Backend_Kineapp.Modelos.MedioPago", b =>
                {
                    b.Property<int>("IdMedio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_medio");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMedio"));

                    b.Property<bool?>("Activo")
                        .HasColumnType("bit");

                    b.Property<int?>("IdDetalleTurno")
                        .HasColumnType("int")
                        .HasColumnName("id_detalle_turno");

                    b.Property<int?>("TipoMedioPago")
                        .HasColumnType("int")
                        .HasColumnName("tipo_medio_pago");

                    b.HasKey("IdMedio");

                    b.ToTable("Medio_pago", (string)null);
                });

            modelBuilder.Entity("Backend_Kineapp.Modelos.ObraSocial", b =>
                {
                    b.Property<int>("IdObra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_obra");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdObra"));

                    b.Property<string>("Descripcion")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdObra");

                    b.ToTable("Obra_social", (string)null);
                });

            modelBuilder.Entity("Backend_Kineapp.Modelos.Paciente", b =>
                {
                    b.Property<int>("IdPaciente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_paciente");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPaciente"));

                    b.Property<string>("Antecedentes")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Apellido")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<long?>("Dni")
                        .HasColumnType("bigint")
                        .HasColumnName("DNI");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("FechaNacimento")
                        .HasColumnType("date");

                    b.Property<int?>("IdHistorial")
                        .HasColumnType("int")
                        .HasColumnName("IdHistorial");

                    b.Property<int?>("IdObraSocial")
                        .HasColumnType("int")
                        .HasColumnName("Id_obraSocial");

                    b.Property<int?>("IdTurno")
                        .HasColumnType("int")
                        .HasColumnName("Id_turno");

                    b.Property<int?>("IdUsuario")
                        .HasColumnType("int")
                        .HasColumnName("id_usuario");

                    b.Property<string>("Nombre")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<bool?>("Sexo")
                        .HasColumnType("bit");

                    b.Property<string>("Telefono")
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)");

                    b.HasKey("IdPaciente");

                    b.HasIndex("IdHistorial");

                    b.HasIndex("IdObraSocial");

                    b.HasIndex("IdTurno");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Paciente", (string)null);
                });

            modelBuilder.Entity("Backend_Kineapp.Modelos.TipoTratamiento", b =>
                {
                    b.Property<int>("IdTipoTratamiento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_tipo_tratamiento");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoTratamiento"));

                    b.Property<string>("Descripcion")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdTipoTratamiento");

                    b.ToTable("Tipo_tratamiento", (string)null);
                });

            modelBuilder.Entity("Backend_Kineapp.Modelos.Tratamiento", b =>
                {
                    b.Property<int>("IdTratamiento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_tratamiento");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTratamiento"));

                    b.Property<string>("Comentario")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("FechaFin")
                        .HasColumnType("date")
                        .HasColumnName("Fecha_fin");

                    b.Property<DateTime?>("FechaInicio")
                        .HasColumnType("date")
                        .HasColumnName("Fecha_inicio");

                    b.Property<int?>("IdTipoTratamiento")
                        .HasColumnType("int")
                        .HasColumnName("id_tipo_tratamiento");

                    b.Property<string>("Objetivo")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("IdTratamiento");

                    b.HasIndex("IdTipoTratamiento");

                    b.ToTable("Tratamiento", (string)null);
                });

            modelBuilder.Entity("Backend_Kineapp.Modelos.Turno", b =>
                {
                    b.Property<int>("IdTurno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_Turno");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTurno"));

                    b.Property<int?>("IdDetalleTurno")
                        .HasColumnType("int")
                        .HasColumnName("id_detalle_turno");

                    b.Property<string>("Nota")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdTurno");

                    b.HasIndex("IdDetalleTurno");

                    b.ToTable("Turno", (string)null);
                });

            modelBuilder.Entity("Backend_Kineapp.Modelos.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id_usuario");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<int?>("IdKinesiologo")
                        .HasColumnType("int")
                        .HasColumnName("id_kinesiologo");

                    b.Property<int?>("IdPaciente")
                        .HasColumnType("int")
                        .HasColumnName("id_paciente");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("Backend_Kineapp.Modelos.DetalleTurno", b =>
                {
                    b.HasOne("Backend_Kineapp.Modelos.Kinesiologo1", "IdKinesiologoNavigation")
                        .WithMany("DetalleTurnos")
                        .HasForeignKey("IdKinesiologo")
                        .HasConstraintName("FK_Detalle_turno_Kinesiologo1");

                    b.HasOne("Backend_Kineapp.Modelos.MedioPago", "IdMedioPagoNavigation")
                        .WithMany("DetalleTurnos")
                        .HasForeignKey("IdMedioPago")
                        .HasConstraintName("FK_Detalle_turno_Medio_pago");

                    b.HasOne("Backend_Kineapp.Modelos.ObraSocial", "IdObraSocialNavigation")
                        .WithMany("DetalleTurnos")
                        .HasForeignKey("IdObraSocial")
                        .HasConstraintName("FK_Detalle_turno_Obra_social");

                    b.HasOne("Backend_Kineapp.Modelos.Tratamiento", "IdTratamientoNavigation")
                        .WithMany("DetalleTurnos")
                        .HasForeignKey("IdTratamiento")
                        .HasConstraintName("FK_Detalle_turno_Tratamiento");

                    b.Navigation("IdKinesiologoNavigation");

                    b.Navigation("IdMedioPagoNavigation");

                    b.Navigation("IdObraSocialNavigation");

                    b.Navigation("IdTratamientoNavigation");
                });

            modelBuilder.Entity("Backend_Kineapp.Modelos.Kinesiologo1", b =>
                {
                    b.HasOne("Backend_Kineapp.Modelos.Usuario", "IdUsuarioNavigation")
                        .WithMany("Kinesiologo1s")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK_Kinesiologo1_Usuario");

                    b.Navigation("IdUsuarioNavigation");
                });

            modelBuilder.Entity("Backend_Kineapp.Modelos.Paciente", b =>
                {
                    b.HasOne("Backend_Kineapp.Modelos.HistorialMedico", "IdHistorialNavigation")
                        .WithMany("Pacientes")
                        .HasForeignKey("IdHistorial")
                        .HasConstraintName("FK_Paciente_HistorialMedico");

                    b.HasOne("Backend_Kineapp.Modelos.ObraSocial", "IdObraSocialNavigation")
                        .WithMany("Pacientes")
                        .HasForeignKey("IdObraSocial")
                        .HasConstraintName("FK_Paciente_Obra_social1");

                    b.HasOne("Backend_Kineapp.Modelos.Turno", "IdTurnoNavigation")
                        .WithMany("Pacientes")
                        .HasForeignKey("IdTurno")
                        .HasConstraintName("FK_Paciente_Turno");

                    b.HasOne("Backend_Kineapp.Modelos.Usuario", "IdUsuarioNavigation")
                        .WithMany("Pacientes")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK_Paciente_Usuario");

                    b.Navigation("IdHistorialNavigation");

                    b.Navigation("IdObraSocialNavigation");

                    b.Navigation("IdTurnoNavigation");

                    b.Navigation("IdUsuarioNavigation");
                });

            modelBuilder.Entity("Backend_Kineapp.Modelos.Tratamiento", b =>
                {
                    b.HasOne("Backend_Kineapp.Modelos.TipoTratamiento", "IdTipoTratamientoNavigation")
                        .WithMany("Tratamientos")
                        .HasForeignKey("IdTipoTratamiento")
                        .HasConstraintName("FK_Tratamiento_Tipo_tratamiento");

                    b.Navigation("IdTipoTratamientoNavigation");
                });

            modelBuilder.Entity("Backend_Kineapp.Modelos.Turno", b =>
                {
                    b.HasOne("Backend_Kineapp.Modelos.DetalleTurno", "IdDetalleTurnoNavigation")
                        .WithMany("Turnos")
                        .HasForeignKey("IdDetalleTurno")
                        .HasConstraintName("FK_Turno_HistorialMedico");

                    b.Navigation("IdDetalleTurnoNavigation");
                });

            modelBuilder.Entity("Backend_Kineapp.Modelos.DetalleTurno", b =>
                {
                    b.Navigation("Turnos");
                });

            modelBuilder.Entity("Backend_Kineapp.Modelos.HistorialMedico", b =>
                {
                    b.Navigation("Pacientes");
                });

            modelBuilder.Entity("Backend_Kineapp.Modelos.Kinesiologo1", b =>
                {
                    b.Navigation("DetalleTurnos");
                });

            modelBuilder.Entity("Backend_Kineapp.Modelos.MedioPago", b =>
                {
                    b.Navigation("DetalleTurnos");
                });

            modelBuilder.Entity("Backend_Kineapp.Modelos.ObraSocial", b =>
                {
                    b.Navigation("DetalleTurnos");

                    b.Navigation("Pacientes");
                });

            modelBuilder.Entity("Backend_Kineapp.Modelos.TipoTratamiento", b =>
                {
                    b.Navigation("Tratamientos");
                });

            modelBuilder.Entity("Backend_Kineapp.Modelos.Tratamiento", b =>
                {
                    b.Navigation("DetalleTurnos");
                });

            modelBuilder.Entity("Backend_Kineapp.Modelos.Turno", b =>
                {
                    b.Navigation("Pacientes");
                });

            modelBuilder.Entity("Backend_Kineapp.Modelos.Usuario", b =>
                {
                    b.Navigation("Kinesiologo1s");

                    b.Navigation("Pacientes");
                });
#pragma warning restore 612, 618
        }
    }
}
