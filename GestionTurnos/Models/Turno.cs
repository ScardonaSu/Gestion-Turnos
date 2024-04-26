namespace GestionTurnos.Models;

public class Turno
{
    public int Id { get; set; }    
    public string Documento { get; set; }    
    public string Categoria { get; set; }
    public string Ticket { get; set; }
    public string Proceso { get; set; }
    public DateTime FechaTicket { get; set; }    
}