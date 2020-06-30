using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TeacherControlWPF.Entidades;

namespace TeacherControlWPF.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Nacionalidades> Nacionalidades { get; set; }
        public DbSet<Estudiantes> Estudiantes { get; set; }
        public DbSet<Tareas> Tareas { get; set; }
        public DbSet<Adicionales> Adicionales { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging().UseSqlite(@"Data Source= DATA\TeacherControl.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nacionalidades>().HasData(new Nacionalidades { 
                NacionalidadId=1,
                Nacionalidad="Dominicana"});

            modelBuilder.Entity<Usuarios>().HasData(new Usuarios
            {
                UsuarioId = 1,
                Nombres = "Anthony B.",
                Apellidos = "Jiménez L.",
                NombreUsuario = "user01",
                Contrasena = "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4"
            });
        }
    }
}
