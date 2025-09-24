using MiWebApi.Models;
using MiWebApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace MiWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadeteriaController : ControllerBase
    {
        private AccesoADatos accesoADatos;
        public CadeteriaController()
        {
            //esto es el constructor de la clase
            accesoADatos = new AccesoADatos();
        }

        [HttpGet("Pedidos")]
        public IActionResult GetPedidos()
        {
            var listadoPedidos = accesoADatos.GetPedidos();
            return Ok(listadoPedidos);
        }
        [HttpGet("Cadetes")]
        public IActionResult GetCadetes()
        {
            var listadoCadetes = accesoADatos.GetCadetes(); return Ok(listadoCadetes);
        }
        [HttpPost("Pedidos/Agregar")]
        public IActionResult AgregarPedido(Pedido pedido)
        {
            accesoADatos.Add(pedido);
            return Created();
        }
        [HttpPut("Pedidos/Asignar/{idPedido}/{idCadete}")]
        public IActionResult AsignarPedido(int idPedido, int idCadete)
        {
            try
            {
                Pedido? pedido = accesoADatos.Change(idPedido, idCadete);
                return Ok(pedido);

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
                Pedido? pedido = accesoADatos.StateChange(idPedido);
                return Ok(pedido);
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
                Pedido? pedido = accesoADatos.Change(idPedido, idCadeteNuevo);
                return Ok(pedido);

            }
            catch (KeyNotFoundException ex)
            {

                return NotFound(ex.Message);
            }
        }
    }
}