using System.Security.Claims;
using GestionTurnos.Data;
using GestionTurnos.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionTurnos.Controllers;

public class AsesoresController : Controller
{

    private readonly BaseContext _Context;
    
    public AsesoresController(BaseContext context)
    {
        _Context = context;
    }
    
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string correo, string password)
    {
        
        var aseseor = await _Context.Asesores.FirstOrDefaultAsync(e => e.Correo == correo && e.Password == password);

        if (aseseor != null)
        {

            _Context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        
        return RedirectToAction("Login", "Asesores");

    }
    

    public async Task<IActionResult> Logout()
    {
        /*await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        HttpContext.Session.Clear();
        HttpContext.Session.Remove("session");*/
        
        return RedirectToAction("Login", "Asesores");
    }
    
    
    
    public IActionResult Create()
    {
        return View(); 
    }

    [HttpPost]
    public async Task<IActionResult> Create(Asesor _asesor)
    {
        _Context.Asesores.Add(_asesor);
        await _Context.SaveChangesAsync();
        return RedirectToAction("Login", "Asesores");
    }
    
    



}