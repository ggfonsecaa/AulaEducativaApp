using Microsoft.EntityFrameworkCore;
using AulaEducativa.App.Dominio.Entidades;

namespace AulaEducativa.App.Persistencia.Datos
{
    public class AulaEducativaContext : DbContext
    {

        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<GradoAcademico> GradosAcademicos { get; set; }
        public DbSet<Institucion> Instituciones { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) {
            if (!dbContextOptionsBuilder.IsConfigured) {
                dbContextOptionsBuilder.UseSqlServer("Data source = (localdb)\\MSSQLLocalDB; Initial Catalog = AulaEducativaApp");
            }
        }
    }
}
