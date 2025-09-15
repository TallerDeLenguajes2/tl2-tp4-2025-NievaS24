namespace MiWebApi.Models
{
    public class Pedido
    {
        public int Numero { get; set; }
        public string Observacion { get; set; }
        public Cliente Cliente { get; set; }
        public bool Estado { get; private set; } = false;
        public Cadete? CadeteACargo { get; private set; } = null;

        public Pedido(int numero, string observacion, Cliente cliente, bool estado)
        {
            Numero = numero;
            Observacion = observacion;
            Cliente = cliente;
            Estado = false;
            CadeteACargo = null;
        }
        public string VerDireccionCliente()
        {
            return Cliente.Direccion;
        }
        public string VerDatosCliente()
        {
            string datos = $"Nombre: {Cliente.Nombre} - Telefono: {Cliente.Telefono} - Direccion: {Cliente.Direccion} - Referencia Direccion: {Cliente.Referencia}";
            return datos;
        }
        public void CambiarCadete(Cadete cadete)
        {
            CadeteACargo = cadete;
        }
        public void CambiarEstado()
        {
            Estado = true;
        }
    }
}