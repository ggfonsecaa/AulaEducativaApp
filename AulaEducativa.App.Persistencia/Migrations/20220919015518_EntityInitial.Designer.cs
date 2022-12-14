// <auto-generated />
using System;
using AulaEducativa.App.Persistencia.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AulaEducativa.App.Persistencia.Migrations
{
    [DbContext(typeof(AulaEducativaContext))]
    [Migration("20220919015518_EntityInitial")]
    partial class EntityInitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AulaEducativa.App.Dominio.Entidades.Actividad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte[]>("Adjunto")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Calificacion")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("EstudianteId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaEntrega")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaLimite")
                        .HasColumnType("datetime2");

                    b.Property<int>("MateriaId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("EstudianteId");

                    b.HasIndex("MateriaId");

                    b.ToTable("Actividad");
                });

            modelBuilder.Entity("AulaEducativa.App.Dominio.Entidades.Estudiante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Direccion")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Edad")
                        .HasColumnType("int");

                    b.Property<int?>("GradoAcademicoId")
                        .HasColumnType("int");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Telefono")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GradoAcademicoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Estudiante");
                });

            modelBuilder.Entity("AulaEducativa.App.Dominio.Entidades.GradoAcademico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("GradoAcademico");
                });

            modelBuilder.Entity("AulaEducativa.App.Dominio.Entidades.Institucion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Institucion");
                });

            modelBuilder.Entity("AulaEducativa.App.Dominio.Entidades.Materia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GradoAcademicoId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("GradoAcademicoId");

                    b.ToTable("Materia");
                });

            modelBuilder.Entity("AulaEducativa.App.Dominio.Entidades.Profesor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Direccion")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Edad")
                        .HasMaxLength(100)
                        .HasColumnType("int");

                    b.Property<int?>("GradoAcademicoId")
                        .HasColumnType("int");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Telefono")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GradoAcademicoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Profesor");
                });

            modelBuilder.Entity("AulaEducativa.App.Dominio.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("InstitucionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InstitucionId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("EstudianteMateria", b =>
                {
                    b.Property<int>("EstudiantesId")
                        .HasColumnType("int");

                    b.Property<int>("MateriasId")
                        .HasColumnType("int");

                    b.HasKey("EstudiantesId", "MateriasId");

                    b.HasIndex("MateriasId");

                    b.ToTable("EstudianteMateria");
                });

            modelBuilder.Entity("AulaEducativa.App.Dominio.Entidades.Actividad", b =>
                {
                    b.HasOne("AulaEducativa.App.Dominio.Entidades.Estudiante", "Estudiante")
                        .WithMany("Actividades")
                        .HasForeignKey("EstudianteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AulaEducativa.App.Dominio.Entidades.Materia", "Materia")
                        .WithMany("Actividades")
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estudiante");

                    b.Navigation("Materia");
                });

            modelBuilder.Entity("AulaEducativa.App.Dominio.Entidades.Estudiante", b =>
                {
                    b.HasOne("AulaEducativa.App.Dominio.Entidades.GradoAcademico", "GradoAcademico")
                        .WithMany("Estudiantes")
                        .HasForeignKey("GradoAcademicoId");

                    b.HasOne("AulaEducativa.App.Dominio.Entidades.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GradoAcademico");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("AulaEducativa.App.Dominio.Entidades.Materia", b =>
                {
                    b.HasOne("AulaEducativa.App.Dominio.Entidades.GradoAcademico", "GradoAcademico")
                        .WithMany("Materias")
                        .HasForeignKey("GradoAcademicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GradoAcademico");
                });

            modelBuilder.Entity("AulaEducativa.App.Dominio.Entidades.Profesor", b =>
                {
                    b.HasOne("AulaEducativa.App.Dominio.Entidades.GradoAcademico", "GradoAcademico")
                        .WithMany("Profesores")
                        .HasForeignKey("GradoAcademicoId");

                    b.HasOne("AulaEducativa.App.Dominio.Entidades.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GradoAcademico");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("AulaEducativa.App.Dominio.Entidades.Usuario", b =>
                {
                    b.HasOne("AulaEducativa.App.Dominio.Entidades.Institucion", "Institucion")
                        .WithMany("Usuarios")
                        .HasForeignKey("InstitucionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institucion");
                });

            modelBuilder.Entity("EstudianteMateria", b =>
                {
                    b.HasOne("AulaEducativa.App.Dominio.Entidades.Estudiante", null)
                        .WithMany()
                        .HasForeignKey("EstudiantesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AulaEducativa.App.Dominio.Entidades.Materia", null)
                        .WithMany()
                        .HasForeignKey("MateriasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AulaEducativa.App.Dominio.Entidades.Estudiante", b =>
                {
                    b.Navigation("Actividades");
                });

            modelBuilder.Entity("AulaEducativa.App.Dominio.Entidades.GradoAcademico", b =>
                {
                    b.Navigation("Estudiantes");

                    b.Navigation("Materias");

                    b.Navigation("Profesores");
                });

            modelBuilder.Entity("AulaEducativa.App.Dominio.Entidades.Institucion", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("AulaEducativa.App.Dominio.Entidades.Materia", b =>
                {
                    b.Navigation("Actividades");
                });
#pragma warning restore 612, 618
        }
    }
}
