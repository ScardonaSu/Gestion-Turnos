using System.Security.Claims;
using GestionTurnos.Data;
using GestionTurnos.Models;
<<<<<<< HEAD
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
=======
using Microsoft.AspNetCore.Identity;
>>>>>>> d8e829df6229074679061d7e8d2e8ffa41bcc2fb
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionTurnos.Controllers;

public class AsesoresController : Controller
{

<<<<<<< HEAD
    private readonly BaseContext _Context;
    
=======
    public readonly BaseContext _Context;
    private object Password;

>>>>>>> d8e829df6229074679061d7e8d2e8ffa41bcc2fb
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
        Asesor newAsesor = new Asesor{
            
            Password = BCrypt.Net.BCrypt.HashPassword(_asesor.Password)

        };
        _asesor.Password = newAsesor.Password;

        _Context.Asesores.Add(_asesor);
        await _Context.SaveChangesAsync();
        return RedirectToAction("Login", "Asesores");
    }

}