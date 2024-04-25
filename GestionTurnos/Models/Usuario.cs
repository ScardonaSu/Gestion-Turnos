using Microsoft.AspNetCore.Mvc;

namespace GestionTurnos.Models;

public class Usuario 
{
    
    public int Id { get; set; }
    
    public string Nombre { get; set; }
    
    public string Apellido { get; set; }
    
    public int Documento { get; set; }
    
    public string Celular { get; set; }
    
    public string Edad { get; set; }
    
    public string Grupo_Sanguineo { get; set; }
    
    public string Fecha_Nacimiento { get; set; }
    
    public string Genero { get; set; }
    
    public string Estado_Civil { get; set; }
    
    public string Direccion { get; set; }
    
}