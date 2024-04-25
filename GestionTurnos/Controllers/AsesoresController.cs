using System.Security.Claims;
using GestionTurnos.Data;
using GestionTurnos.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

    [HttpPost]
    public async Task<IActionResult> Login(string correo, string password)
    {
        
        var asesor = await _Context.Asesores.FirstOrDefaultAsync(e => e.Correo == correo);
        var verifyPassword = BCrypt.Net.BCrypt.Verify(password,asesor.Password); 
        
        if (asesor != null && verifyPassword == true)
        {
            this.HttpContext.Session.SetInt32("session",asesor.Id);
            return RedirectToAction("Create", "Asesores");
        }
        
        return RedirectToAction("Login", "Asesores");

    }
    

    public async Task<IActionResult> Logout()
    {
/*         await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);*/
        HttpContext.Session.Remove("session");
        
        return RedirectToAction("Login", "Asesores");
    }
    
    
    
    public IActionResult Create()
    {
        /* ////////////// GUARDIAN  ///////// */
        var SesionUser = HttpContext.Session.GetInt32("session");
        if (SesionUser != null)
        {
            return RedirectToAction("Index", "Asesores"); /* COLOCAR EN VISTA DESPUES DE QUE EL USUARIO INGRESA AL SISTEMA Y COLOCAR LAS VISTAS CORRESPONDIENTES */
        }else
        {
            return View();
        }
        
    }

    [HttpPost]
    public async Task<IActionResult> Create(Asesor _asesor)
    {
      
        _asesor.Password = BCrypt.Net.BCrypt.HashPassword(_asesor.Password);
        _Context.Asesores.Add(_asesor);
        await _Context.SaveChangesAsync();
        return RedirectToAction("Login", "Asesores");
    }

}