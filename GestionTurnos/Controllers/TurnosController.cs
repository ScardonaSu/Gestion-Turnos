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

        string seleccion = "";
        string turno = "";
        var result = await _context.Categorias.FirstOrDefaultAsync(c => c.Abreviacion == siglas);
        int contador = result.Contador +1;

        turno = siglas+"-"+(contador < 10 ? "00"+contador: "0"+contador);

        ViewBag.Turno = turno;
        return View();
    }

    public async Task<IActionResult> TomarTurno(string turno){

        string documento = HttpContext.Session.GetString("Documento");

        string siglas = turno.Substring(0,2);
        var result = await _context.Categorias.FirstOrDefaultAsync(c => c.Abreviacion == siglas);

        result.Contador = result.Contador+1; 

        _context.Categorias.Update(result);
        await _context.SaveChangesAsync();

        var turnoIn = new Turno{
            Categoria = result.Nombre,
            Documento = documento,
            Ticket = turno,
            FechaTicket = DateTime.Now,
            Proceso = "En cola"

        };

        _context.Turnos.Add(turnoIn);
        await _context.SaveChangesAsync();


        return RedirectToAction("Index");
    }
}
