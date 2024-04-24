namespace GestionTurnos.Models;

public class Turno
{
    public int Id { get; set; }
    
    public string CC_Usuario { get; set; }
    
    public bool Discapacidad { get; set; }
    
    public string Tipo_gestion { get; set; }
    
    public string Proceso { get; set; }
}