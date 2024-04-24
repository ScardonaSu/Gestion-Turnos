using Microsoft.EntityFrameworkCore;

namespace GestionTurnos.Data;

public class BaseContext: DbContext
{
    public BaseContext(DbContextOptions<BaseContext> options) : base(options)
    {
        
    }
    
    
    
    
}