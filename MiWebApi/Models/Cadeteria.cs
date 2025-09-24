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
            //constructor vacio
        }
        // public int PedidosEntregados(int id)
        // {
        //     Cadete cadeteSeleccionado = ListadoCadetes.FirstOrDefault(c => c.Id == id);
        //     return cadeteSeleccionado != null ? ListadoPedidos.Count(p => p.CadeteACargo == cadeteSeleccionado && p.Estado) : 0;
        // }
        // public int JornalACobrar(int id)
        // {
        //     return PedidosEntregados(id) * 500;
        // }
        // public int TotalAPagar()
        // {
        //     int total = 0;
        //     for (int i = 0; i < ListadoCadetes.Count(); i++)
        //     {
        //         total += JornalACobrar(ListadoCadetes[i].Id);
        //     }
        //     return total;
        // }

        public Pedido DarAltaPedido(string observacion, string nombreCliente, string direccion, string telefono, string Referencia)
        {
            int numero = ListadoPedidos.Any() ? ListadoPedidos.Max(p => p.Numero) + 1 : 1;
            Pedido nuevo = new(numero, observacion, new Cliente(nombreCliente, direccion, telefono, Referencia));
            ListadoPedidos.Add(nuevo);
            return nuevo;
        }
        public void AsignarCadeteAPedido(int idPedido, int idCadete)
        {
            Cadete? cadeteACargo = ListadoCadetes.FirstOrDefault(c => c.Id == idCadete) ?? throw new KeyNotFoundException($"El cadete {idCadete} no existe.");
            Pedido? pedidoSeleccionado = ListadoPedidos.FirstOrDefault(p => p.Numero == idPedido) ?? throw new KeyNotFoundException($"El pedido {idPedido} no existe.");
            pedidoSeleccionado.CambiarCadete(cadeteACargo);
        }
        public void CambiarEstado(int id)
        {
            Pedido? pedidoEntregado = ListadoPedidos.FirstOrDefault(pedido => pedido.Numero == id);
            pedidoEntregado?.CambiarEstado(); //si no es null cambia el estado
        }
    }
}