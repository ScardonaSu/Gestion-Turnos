using System.Security.Claims;
using GestionTurnos.Data;
using GestionTurnos.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionTurnos.Controllers;

public class TelevisorController : Controllers
{
    public readonly BaseContext _Context;

    public TelevisorController(BaseContext context)
    {
        _Context = context;
    }
    public IActionResult Index()
    {
        return View();
    }
}
