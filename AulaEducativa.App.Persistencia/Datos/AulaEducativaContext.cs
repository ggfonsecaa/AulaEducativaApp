using Microsoft.EntityFrameworkCore;
using AulaEducativa.App.Dominio.Entidades;

namespace AulaEducativa.App.Persistencia.Datos
{
    public class AulaEducativaContext : DbContext
    {

        public DbSet<Actividad> Actividad { get; set; }
        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<GradoAcademico> GradoAcademico { get; set; }
        public DbSet<Institucion> Institucion { get; set; }
        public DbSet<Materia> Materia { get; set; }
        public DbSet<Profesor> Profesor { get; set; }
        public DbSet<Usuario> Usuario { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) {
            if (!dbContextOptionsBuilder.IsConfigured) {
                dbContextOptionsBuilder.UseSqlServer("Data Source=SQL8002.site4now.net;Initial Catalog=db_a8d4f8_aulaeducativaapp;User Id=db_a8d4f8_aulaeducativaapp_admin;Password=Asdf1234*");
            }
        }
    }
}