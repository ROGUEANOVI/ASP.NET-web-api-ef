using Microsoft.EntityFrameworkCore;
using WebApiEF.Models;

namespace WebApiEF.DbContexts;

public class TaskContext : DbContext
{
  public TaskContext(DbContextOptions<TaskContext> options) : base(options)
  {

  }

  public DbSet<Category>? Categories { get; set; }
  public DbSet<Models.Task>? Tasks { get; set; }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    List<Category> categoriesInit = new List<Category>();

    categoriesInit.Add(new Category(){
      CategoryId = Guid.Parse("e361edbb-6c63-4ed3-b2e5-f32f5adef57c"), 
      Name = "Actividades Pendientes", 
      Weight = 20
    });

    categoriesInit.Add(new Category(){
      CategoryId = Guid.Parse("0f1ef1d9-1ea5-4196-bb59-9cf9a28dbabb"), 
      Name = "Actividades Personales", 
      Weight = 50
    });


    modelBuilder.Entity<Category>(category =>
      {
        category.ToTable("CATEGORIES");
        category.HasKey(p => p.CategoryId);
        category.Property(p => p.Name).IsRequired().HasMaxLength(150);
        category.Property(p => p.Description);
        category.Property(p => p.Weight);

        category.HasData(categoriesInit);
      }
    );


    List<Models.Task> tasksInit = new List<Models.Task>();

    tasksInit.Add(new Models.Task(){
      TaskId = Guid.Parse("ecdde551-9a9f-484e-9a23-7dd982fb7882"), 
      Title = "Crear web app de prueba", 
      Description = "Crear web app de prueba utilizando EF",
      TaskPriority= Priority.Low,
      CreationDate = DateTime.Now,
      CategoryId = Guid.Parse("e361edbb-6c63-4ed3-b2e5-f32f5adef57c"),

    });

    tasksInit.Add(new Models.Task(){
      TaskId = Guid.Parse("959ad597-82a6-49fa-a548-e679bdf3e72a"), 
      Title = "Diseñar modelo E/R", 
      Description = "Diseñar modelo E/R de la base de datos del nuevo cliente", 
      TaskPriority= Priority.High,
      CreationDate = DateTime.Now,
      CategoryId = Guid.Parse("e361edbb-6c63-4ed3-b2e5-f32f5adef57c")
    });

    tasksInit.Add(new Models.Task(){
      TaskId = Guid.Parse("3531ca67-ca17-4061-872b-ceb0d59f1d3b"), 
      Title = "Ir al banco", 
      Description = "Ir a pedir el prestamo al banco", 
      TaskPriority= Priority.High,
      CreationDate = DateTime.Now,
      CategoryId = Guid.Parse("0f1ef1d9-1ea5-4196-bb59-9cf9a28dbabb")
    });

    tasksInit.Add(new Models.Task(){
      TaskId = Guid.Parse("c1842460-d11f-447a-bdc1-ec751fd88b18"), 
      Title = "Lavar la moto", 
      Description = "Llevar la moto al lavadero", 
      TaskPriority= Priority.Half,
      CreationDate = DateTime.Now, 
      CategoryId = Guid.Parse("0f1ef1d9-1ea5-4196-bb59-9cf9a28dbabb")
    });
    
    modelBuilder.Entity<Models.Task>(category =>
      {
        category.ToTable("TASKS");
        category.HasKey(p => p.TaskId);
        category.Property(p => p.Title).IsRequired().HasMaxLength(200);
        category.Property(p => p.Description);
        category.Ignore(p => p.Resume);
        category.Property(p => p.CreationDate);
        category.HasOne(p => p.Category).WithMany(p => p.Tasks).HasForeignKey(p => p.CategoryId);

        category.HasData(tasksInit);
      }
    );


  }
} 