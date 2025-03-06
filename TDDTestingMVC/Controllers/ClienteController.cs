using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TDDTestingMVC.data;

namespace TDDTestingMVC.Controllers
{
    public class ClienteController : Controller
    {
        ClienteDataAccessLayer objCliente = new ClienteDataAccessLayer();

        public IActionResult Index()
        {
            List<Cliente> clientes = new List<Cliente>();
            clientes = objCliente.GetAllClientes().ToList();
            return View(clientes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Convertir el valor del checkbox a "Activo" o "Inactivo"
                    cliente.Estado = cliente.EstadoBool ? "Activo" : "Inactivo";
                    objCliente.AddCliente(cliente);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                // Registrar el error
                ILogger<ClienteController> logger = null;
            }
            return View(cliente);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Cliente cliente = objCliente.GetClienteData(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] Cliente cliente)
        {
            if (id != cliente.Codigo)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                // Convertir el valor del checkbox a "activo" o "inactivo"
                cliente.Estado = cliente.EstadoBool ? "Activo" : "Inactivo";

                objCliente.UpdateCliente(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Cliente cliente = objCliente.GetClienteData(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            objCliente.DeleteCliente(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Cliente cliente = objCliente.GetClienteData(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }
    }
}
