using GestionTurnos.Data;
using GestionTurnos.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionTurnos.Controllers;

public class TurnosController : Controller
{

    private readonly BaseContext _context;
    
    public TurnosController(BaseContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var query = from Asesor in _context.Asesores
            join turno in _context.Turnos on Asesor.Documento equals turno.Documento select new {ccuser = turno.Documento, nameAsesor = Asesor.Nombre};
        
        return View(query);
    }


}