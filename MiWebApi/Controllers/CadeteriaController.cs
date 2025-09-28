using MiWebApi.Models;
using MiWebApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace MiWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadeteriaController : ControllerBase
    {
        private Cadeteria cadeteria;
        private AccesoADatosCadeteria ADatosCadeteria;
        private AccesoADatosCadetes ADatosCadetes;
        private AccesoADatosPedidos ADatosPedidos;
        public CadeteriaController()
        {
            ADatosCadeteria = new AccesoADatosCadeteria();
            ADatosCadetes = new AccesoADatosCadetes();
            ADatosPedidos = new AccesoADatosPedidos();

            cadeteria = ADatosCadeteria.Obtener();
            cadeteria.AgregarListaCadetes(ADatosCadetes.Obtener());
            cadeteria.AgregarListaPedidos(ADatosPedidos.Obtener());
        }

        [HttpGet("Pedidos")]
        public IActionResult GetPedidos()
        {
            return Ok(cadeteria.ListadoPedidos);
        }

        [HttpGet("Cadetes")]
        public IActionResult GetCadetes()
        {
            return Ok(cadeteria.ListadoCadetes);
        }

        [HttpPost("Pedidos/Agregar")]
        public IActionResult AgregarPedido(Pedido pedido)
        {
            cadeteria.DarAltaPedido(pedido);
            ADatosPedidos.Guardar(cadeteria.ListadoPedidos);
            return Created();
        }

        [HttpPut("Pedidos/Asignar/{idPedido}/{idCadete}")]
        public IActionResult AsignarPedido(int idPedido, int idCadete)
        {
            try
            {
                cadeteria.AsignarCadeteAPedido(idPedido, idCadete);
                ADatosPedidos.Guardar(cadeteria.ListadoPedidos);
                return Ok($"Se asigno el cadete {idCadete} al pedido {idPedido} correctamente.");

            }
            catch (KeyNotFoundException ex)
            {

                return NotFound(ex.Message);
            }
        }

        [HttpPut("Pedidos/CambiarEstado/{idPedido}")]
        public IActionResult CambiarEstadoPedido(int idPedido)
        {
            try
            {
                cadeteria.CambiarEstado(idPedido);
                ADatosPedidos.Guardar(cadeteria.ListadoPedidos);
                return Ok("Se realizo el cambio de estado correctamente.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("Pedidos/Reasignar/{idPedido}/{idCadeteNuevo}")]
        public IActionResult CambiarCadetePedido(int idPedido, int idCadeteNuevo)
        {
            try
            {
                cadeteria.AsignarCadeteAPedido(idPedido, idCadeteNuevo);
                ADatosPedidos.Guardar(cadeteria.ListadoPedidos);
                return Ok($"Se reasigno el pedido {idPedido} al cadete {idCadeteNuevo} correctamente.");

            }
            catch (KeyNotFoundException ex)
            {

                return NotFound(ex.Message);
            }
        }
    }
}