using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace projectef.Models
{
    public class TareasContext : DbContext
    {
        public DbSet<Categoria> Categorias {get; set;}
        public DbSet<Tarea> Tareas {get; set;}

        public TareasContext(DbContextOptions<TareasContext> options) : base(options)
        {
             
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            
            List<Categoria> categoriasInit = new List<Categoria>();
            categoriasInit.Add(new Categoria() {
                CategoriaId = Guid.Parse("4d5fa2fc-b658-414c-8b9c-8670a42bc2b4"),
                Nombre = "Actividades Pendientes",
                Peso = 20
            });
            categoriasInit.Add(new Categoria() {
                CategoriaId = Guid.Parse("4d5fa2fc-b658-414c-8b9c-8670a42bc2b5"),
                Nombre = "Actividades Personales",
                Peso = 50
            });
            categoriasInit.Add(new Categoria() {
                CategoriaId = Guid.Parse("4d5fa2fc-b658-414c-8b9c-8670a42bc2b6"),
                Nombre = "Actividades Profesionales",
                Peso = 90
            });

            modelbuilder.Entity<Categoria>(categoria => {
                categoria.ToTable("Categoria");
                categoria.HasKey(p => p.CategoriaId);
                categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
                categoria.Property(p => p.Descripcion);
                categoria.Property(p => p.Peso);

                categoria.HasData(categoriasInit);
            });
            

             List<Tarea> tareasInit = new List<Tarea>();
             tareasInit.Add(new Tarea {
                TareaId = Guid.Parse("5cbb38c4-0d16-4220-a835-feee920d750a"),
                CategoriaId = Guid.Parse("4d5fa2fc-b658-414c-8b9c-8670a42bc2b4"),
                Titulo = "Mi tarea 1",
                Descripcion = "Descripcion de la tarea 1",
                Resumen = "Esto es un resumen de la tarea 1"
             });

             tareasInit.Add(new Tarea {
                TareaId = Guid.Parse("9f8b42d3-9902-4634-9c82-427d8888b1be"),
                CategoriaId = Guid.Parse("4d5fa2fc-b658-414c-8b9c-8670a42bc2b5"),
                Titulo = "Mi tarea 2",
                Descripcion = "Descripcion de la tarea 2",
                PrioridadTarea = Prioridad.Media,
                Resumen = "Esto es un resumen de la tarea 2"
             });

             tareasInit.Add(new Tarea {
                TareaId = Guid.Parse("2ad473bf-f9f4-41c2-aa9c-0066da6efaf5"),
                CategoriaId = Guid.Parse("4d5fa2fc-b658-414c-8b9c-8670a42bc2b6"),
                Titulo = "Mi tarea 3",
                Descripcion = "Descripcion de la tarea 3",
                PrioridadTarea = Prioridad.Baja,
                FechaCreacion = Convert.ToDateTime("2023-03-06"),
                Resumen = "Esto es un resumen de la tarea 3"
             });


            modelbuilder.Entity<Tarea>( tarea => {
                tarea.ToTable("Tarea");
                tarea.HasKey(p => p.TareaId);
                tarea.HasOne<Categoria>(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);
                tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
                tarea.Property(p => p.Descripcion);
                tarea.Property(p => p.PrioridadTarea);
                tarea.Property(p => p.FechaCreacion).HasDefaultValue(DateTime.UtcNow);
                tarea.Ignore(p => p.Resumen);

                tarea.HasData(tareasInit);
            });

        }
    }
}