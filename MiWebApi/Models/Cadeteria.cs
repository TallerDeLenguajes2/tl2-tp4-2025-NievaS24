namespace MiWebApi.Models
{
    public class Cadeteria
    {
        public string Nombre { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public List<Cadete> ListadoCadetes { get; set; } = new();
        public List<Pedido> ListadoPedidos { get; set; } = new();

        public Cadeteria()
        {

        }

        public void AgregarListaCadetes(List<Cadete> cadetes)
        {
            ListadoCadetes = cadetes;
        }
        public void AgregarListaPedidos(List<Pedido> pedidos)
        {
            ListadoPedidos = pedidos;
        }
        public void DarAltaPedido(Pedido pedido)
        {
            pedido.Numero = ListadoPedidos.Any() ? ListadoPedidos.Max(p => p.Numero) + 1 : 1;
            pedido.CadeteACargo = null;
            pedido.Estado = false;
            ListadoPedidos.Add(pedido);
        }
        public void AsignarCadeteAPedido(int idPedido, int idCadete)
        {
            Cadete? cadeteACargo = ListadoCadetes.FirstOrDefault(c => c.Id == idCadete) ?? throw new KeyNotFoundException($"El cadete {idCadete} no existe.");
            Pedido? pedidoSeleccionado = ListadoPedidos.FirstOrDefault(p => p.Numero == idPedido) ?? throw new KeyNotFoundException($"El pedido {idPedido} no existe.");
            pedidoSeleccionado.CambiarCadete(cadeteACargo);
        }
        public void CambiarEstado(int id)
        {
            Pedido? pedidoEntregado = ListadoPedidos.FirstOrDefault(pedido => pedido.Numero == id) ?? throw new KeyNotFoundException($"El pedido {id} no existe.");
            pedidoEntregado.CambiarEstado();
        }
    }
}