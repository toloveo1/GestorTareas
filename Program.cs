using GestorTareas.Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TaskContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllersWithViews(); // con esto habilitamos el MVC

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



 using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<TaskContext>();
    // Asegúrate de que se aplica la migración para que la tabla esté lista
    context.Database.Migrate();
    // Agregar datos iniciales si la tabla está vacía
    if (!context.Tasks.Any())
    {
        context.Tasks.AddRange(
            new Tarea { Name = "Visita comercial", Description = "Dia 14, 09:00 auditoria tipo A, avisar equipo" },
            new Tarea { Name = "Entrevista cliente", Description = "Meeting con cliente UK, formalizar contrato" }
        );
        context.SaveChanges();
    }
}


app.Run();

builder.Services.AddDbContext<TaskContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

