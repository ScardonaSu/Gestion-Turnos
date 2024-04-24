using GestionTurnos.Data;
using GestionTurnos.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionTurnos.Controllers;

public class AsesoresController : Controller
{

    public readonly BaseContext _Context;
    
    public AsesoresController(BaseContext context)
    {
        _Context = context;
    }
    
    public IActionResult Create()
    {
        return View(); 
    }

    [HttpPost]
    public async Task<IActionResult> Create(Asesor _asesor)
    {
        if (ModelState.IsValid)
        {
            _Context.Asesores.Add(_asesor);
            await _Context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
        else
        {
            return View();
        }
    }
    
    



}