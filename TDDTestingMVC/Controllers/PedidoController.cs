using Microsoft.AspNetCore.Mvc;
using TDDTestingMVC.data;

namespace TDDTestingMVC.Controllers
{
    public class PedidoController : Controller
    {
        PedidoDataAccessLayer objPedido = new PedidoDataAccessLayer();
        ClienteDataAccessLayer objCliente = new ClienteDataAccessLayer();

        public IActionResult Index()
        {
            List<Pedido> pedidos = new List<Pedido>();
            pedidos = objPedido.GetAllPedidos().ToList();
            return View(pedidos);
        }

        public IActionResult Create()
        {
            // Obtener la lista de clientes para el dropdown
            ViewBag.Clientes = objCliente.GetAllClientes();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                objPedido.AddPedido(pedido);
                return RedirectToAction("Index");
            }

            // Si hay errores, volver a cargar la lista de clientes
            ViewBag.Clientes = objCliente.GetAllClientes();
            return View(pedido);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pedido pedido = objPedido.GetPedidoData(id);
            if (pedido == null)
            {
                return NotFound();
            }

            // Obtener la lista de clientes para el dropdown
            ViewBag.Clientes = objCliente.GetAllClientes();
            return View(pedido);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] Pedido pedido)
        {
            if (id != pedido.PedidoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                objPedido.UpdatePedido(pedido);
                return RedirectToAction("Index");
            }

            // Si hay errores, volver a cargar la lista de clientes
            ViewBag.Clientes = objCliente.GetAllClientes();
            return View(pedido);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pedido pedido = objPedido.GetPedidoData(id);
            if (pedido == null)
            {
                return NotFound();
            }

            // Obtener el nombre del cliente para mostrarlo
            Cliente cliente = objCliente.GetClienteData(pedido.ClienteID);
            if (cliente != null)
            {
                ViewBag.NombreCliente = $"{cliente.Nombres} {cliente.Apellidos}";
            }

            return View(pedido);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            objPedido.DeletePedido(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pedido pedido = objPedido.GetPedidoData(id);
            if (pedido == null)
            {
                return NotFound();
            }

            // Obtener el nombre del cliente para mostrarlo
            Cliente cliente = objCliente.GetClienteData(pedido.ClienteID);
            if (cliente != null)
            {
                ViewBag.NombreCliente = $"{cliente.Nombres} {cliente.Apellidos}";
            }

            return View(pedido);
        }

        // Método para cambiar el estado de un pedido
        public IActionResult CambiarEstado(int id, string nuevoEstado)
        {
            if (id <= 0)
            {
                return BadRequest("ID de pedido inválido");
            }

            objPedido.CambiarEstadoPedido(id, nuevoEstado);
            return RedirectToAction("Index");
        }

        // Método para filtrar pedidos por cliente
        public IActionResult PedidosPorCliente(int clienteId)
        {
            List<Pedido> pedidos = objPedido.GetPedidosByCliente(clienteId);
            ViewBag.ClienteId = clienteId;

            Cliente cliente = objCliente.GetClienteData(clienteId);
            if (cliente != null)
            {
                ViewBag.NombreCliente = $"{cliente.Nombres} {cliente.Apellidos}";
            }

            return View("Index", pedidos);
        }

        // Método para filtrar pedidos por estado
        public IActionResult PedidosPorEstado(string estado)
        {
            List<Pedido> pedidos = objPedido.GetPedidosByEstado(estado);
            ViewBag.Estado = estado;
            return View("Index", pedidos);
        }
    }
}