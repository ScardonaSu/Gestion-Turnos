using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionTurnos.Data;
using GestionTurnos.Models;

namespace GestionTurnos.Controllers;

public class TurnosController : Controller {
    public readonly BaseContext _context;
    public TurnosController(BaseContext context) {
        _context = context;
    }
    
    public IActionResult Index() {
        return View();
    }

    public async Task<IActionResult> SeleccionarCategoria (string documento) {
        HttpContext.Session.SetString("Documento",documento);

        ViewBag.Documento = HttpContext.Session.GetString("Documento");

        return View(await _context.Categorias.ToArrayAsync());
    }
}
