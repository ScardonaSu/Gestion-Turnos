namespace GestionTurnos.Models;

public class Asesor
{
    
    public int Id { get; set; }
    
    public string Nombre { get; set; }
    
    public string Apellido { get; set; }
    
    public string Correo { get; set; }
    
    public string Documento { get; set; }
    
    public string Password { get; set; }
    
    public string Conocimientos { get; set; }
    
    public int Clientes_Atendidos { get; set; }
    
    /*public int Id_Modulo { get; set; }*/
    
}