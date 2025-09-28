namespace MiWebApi.Models
{
    public class Pedido
    {
        public int Numero { get; set; }
        public string? Observacion { get; set; }
        public Cliente? Cliente { get; set; }
        public bool Estado { get; set; } = false;
        public Cadete? CadeteACargo { get; set; } = null;

        public Pedido()
        {

        }

        public void CambiarCadete(Cadete nuevoCadete)
        {
            CadeteACargo = nuevoCadete;
        }

        public void CambiarEstado()
        {
            Estado = !Estado;
        }
    }
}