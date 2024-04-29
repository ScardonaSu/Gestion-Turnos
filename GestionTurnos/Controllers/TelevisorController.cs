using System.Security.Claims;
using GestionTurnos.Data;
using GestionTurnos.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionTurnos.Controllers;
public class TelevisorController : Controller
{
    public readonly BaseContext _DbContext;

    public TelevisorController(BaseContext context)
    {
        _DbContext = context;
    }
    public IActionResult Index()
    {
        return View();
    }
}
