using GestionTurnos.Data;
using GestionTurnos.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GestionTurnos.Controllers;

public class AsesoresController : Controller
{

    public readonly BaseContext _Context;
    private object Password;

    public AsesoresController(BaseContext context)
    {
        _Context = context;
    }
    
    public IActionResult Login()
    {

        return View();
    }
    
    public IActionResult Create()
    {
        return View(); 
    }

    [HttpPost]
    public async Task<IActionResult> Create(Asesor _asesor)
    {
       /*  Asesor newAsesor = new Asesor{
            
            Password = BCrypt.Net.BCrypt.HashPassword(_asesor.Password)

        };
        _asesor.Password = newAsesor.Password; */

        _asesor.Password = BCrypt.Net.BCrypt.HashPassword(_asesor.Password);
        _Context.Asesores.Add(_asesor);
        await _Context.SaveChangesAsync();
        return RedirectToAction("Login", "Asesores");
    }

}