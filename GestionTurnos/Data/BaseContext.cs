using GestionTurnos.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionTurnos.Data;

public class BaseContext: DbContext
{
    public BaseContext(DbContextOptions<BaseContext> options) : base(options)
    {
        
    }
    
    public DbSet<Asesor> Asesores { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Turno> Turnos { get; set; }
    public DbSet<Categoria> Categorias {get; set;}
        
}