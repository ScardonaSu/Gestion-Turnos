using GestionTurnos.Data;
using Microsoft.AspNetCore.Mvc;

namespace GestionTurnos.Controllers;

public class ModulosController : Controller
{
    
    public readonly BaseContext _context;

    public ModulosController(BaseContext context)
    {
        _context = context;
    }
    
    public IActionResult Index()
    {
        return View();
    }
    
    
    
}