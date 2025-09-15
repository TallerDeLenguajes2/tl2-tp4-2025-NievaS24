namespace MiWebApi.Models
{
    public class Cadete
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Direccion { get; set; }
        public required string Telefono { get; set; }
    }
}