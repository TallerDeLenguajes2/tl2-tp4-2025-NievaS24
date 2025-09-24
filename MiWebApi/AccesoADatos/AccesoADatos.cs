using System.Text.Json;
using MiWebApi.Models;
namespace MiWebApi.Data
{
    public class AccesoADatos
    {
        private const string FilePath = "data/cadeteria.json";
        private static readonly object _lock = new();
        private Cadeteria LeerDatos()
        {
            if (!File.Exists(FilePath))
            {
                return new Cadeteria();
            }
            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<Cadeteria>(json) ?? new Cadeteria();
        }
        private void GuardarCadeteria(Cadeteria cadeteria)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(cadeteria, options);
            File.WriteAllText(FilePath, json);
        }
        public List<Pedido> GetPedidos()
        {
            lock (_lock)
            {
                return LeerDatos().ListadoPedidos;
            }
        }
        public List<Cadete> GetCadetes()
        {
            lock (_lock)
            {
                return LeerDatos().ListadoCadetes;
            }
        }
        public void Add(Pedido pedido)
        {
            lock (_lock)
            {
                var cadeteria = LeerDatos();
                cadeteria.DarAltaPedido(pedido.Observacion, pedido.Cliente.Nombre, pedido.VerDireccionCliente(), pedido.Cliente.Telefono, pedido.Cliente.Referencia);
                GuardarCadeteria(cadeteria);
            }
        }
        public Pedido? Change(int idPedido, int idCadete)
        {
            lock (_lock)
            {
                var cadeteria = LeerDatos();
                cadeteria.AsignarCadeteAPedido(idPedido, idCadete);
                GuardarCadeteria(cadeteria);
                return cadeteria.ListadoPedidos.FirstOrDefault(p => p.Numero == idPedido);
            }
        }
    }
}