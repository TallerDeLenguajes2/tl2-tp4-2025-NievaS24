namespace MiWebApi.Models
{
    public class Cliente
    {
        public string Nombre { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Referencia { get; set; } = string.Empty;

        public Cliente()
        {

        }
    }
}