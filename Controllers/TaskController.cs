using Microsoft.AspNetCore.Mvc;
using GestorTareas.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class TaskController : Controller
{
    private readonly TaskContext _context;

    public TaskController(TaskContext context)
    {
        _context = context;
    }

    // Método para mostrar la lista de tareas
    public async Task<IActionResult> Index()
    {
        var tareas = await _context.Tasks.ToListAsync();
        return View(tareas);
    }

    // Método para ver el formulario de creación
    public IActionResult Create()
    {
        return View();
    }

    // Método para procesar la creación de una nueva tarea
    [HttpPost]
    public async Task<IActionResult> Create(Tarea tarea)
    {
        if (ModelState.IsValid)
        {
            _context.Tasks.Add(tarea);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(tarea);
    }

    // Otros métodos vendrán después
}
