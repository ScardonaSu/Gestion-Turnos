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
        if(!string.IsNullOrEmpty(documento)){
            HttpContext.Session.SetString("Documento",documento);
            ViewBag.Documento = HttpContext.Session.GetString("Documento");
            return View(await _context.Categorias.ToArrayAsync());
        }

        return RedirectToAction("Index","Turnos");
    }

    public async Task<IActionResult> Turno(string siglas){

        ViewBag.Documento = HttpContext.Session.GetString("Documento");

        string ticket = "";
        var result = await _context.Categorias.FirstOrDefaultAsync(c => c.Abreviacion == siglas);

        result.Contador = result.Contador+1; 
        ticket = siglas+"-"+(result.Contador < 10 ? "0"+result.Contador: result.Contador);

        ViewBag.Ticket = ticket;

        _context.Categorias.Update(result);
        await _context.SaveChangesAsync();

        var turnoIn = new Turno{
            Categoria = result.Nombre,
            Documento = ViewBag.Documento,
            Ticket = ticket,
            FechaTicket = DateTime.Now,
            Proceso = "En cola"
        };

        _context.Turnos.Add(turnoIn);
        await _context.SaveChangesAsync();

        return View();
    }
}
