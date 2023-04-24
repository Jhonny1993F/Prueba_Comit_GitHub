namespace Prueba_Comit_GitHub.Models
{
    public class Comit
    {
        public int Id { get; set; }
        public DateTime FechaComit { get; set; }
        public string? Descripcion { get; set; }
        public bool Funciono { get; set; }
        public double Calificacion { get; set; }
    }
}
