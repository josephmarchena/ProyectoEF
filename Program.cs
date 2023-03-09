using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectef.Models;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("ProjectDB"));
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    //return Results.Ok("Base datos en memoria: " + dbContext.Database.IsInMemory());
    return Results.Ok("Base datos en SQl: " + dbContext.Database.IsSqlServer());
});

app.MapGet("/api/tareas/{id}/{fecha}", async ([FromServices] TareasContext dbContext, int id, DateTime fecha) => 
{
    var resultado = dbContext.Tareas.Include(p => p.Categoria)
    .Where(a => (int)a.PrioridadTarea == id)
    .Where(a => a.FechaCreacion == fecha);
    return Results.Ok(resultado);
});

app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) => 
{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;
    await dbContext.AddAsync(tarea);

    await dbContext.SaveChangesAsync();

    return Results.Ok(tarea);
});

app.MapPut("/api/tareas/{Guid}", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea, Guid guid) => 
{

    var find = await dbContext.Tareas.FindAsync(guid);

    if (find != null)
    {
        find.FechaCreacion = Convert.ToDateTime("2023-01-10");
        find.Titulo = tarea.Titulo;
        find.Descripcion = tarea.Descripcion;
        find.PrioridadTarea = tarea.PrioridadTarea;

        await dbContext.SaveChangesAsync();
        return Results.Ok(find);
    }else{

        return Results.NotFound();
    }
    
});

app.MapDelete("/api/tareas/{Guid}", async ([FromServices] TareasContext dbContext, Guid guid) => 
{

    var findTask = await dbContext.Tareas.FindAsync(guid);

    if (findTask != null)
    {
        dbContext.Tareas.Remove(findTask);
        await dbContext.SaveChangesAsync();
        return Results.Ok($"Se ha eliminado la Tarea : {findTask}");
    }else{

        return Results.NotFound();
    }
});

app.Run();
