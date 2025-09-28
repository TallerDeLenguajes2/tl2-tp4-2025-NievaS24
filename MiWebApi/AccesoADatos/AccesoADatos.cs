using System.Text.Json;
using MiWebApi.Models;
namespace MiWebApi.Data
{
    public class AccesoADatosCadeteria
    {
        private const string FilePath = "data/cadeteria.json";
        public Cadeteria Obtener()
        {
            if (!File.Exists(FilePath))
            {
                return new Cadeteria();
            }
            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<Cadeteria>(json) ?? new Cadeteria();
        }
    }
    public class AccesoADatosCadetes
    {
        private const string FilePath = "data/Cadetes.json";
        public List<Cadete> Obtener()
        {
            if (!File.Exists(FilePath))
            {
                return new List<Cadete>();
            }
            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<Cadete>>(json) ?? new List<Cadete>();
        }
    }
    public class AccesoADatosPedidos
    {
        private const string FilePath = "data/Pedidos.json";
        public List<Pedido> Obtener()
        {
            if (!File.Exists(FilePath))
            {
                return new List<Pedido>();
            }
            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<Pedido>>(json) ?? new List<Pedido>();
        }

        public void Guardar(List<Pedido> pedidos)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(pedidos, options);
            File.WriteAllText(FilePath, json);
        }
    }
}