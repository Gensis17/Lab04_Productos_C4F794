using Lab04_Productos_C4F794.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab04_Productos_C4F794.Controllers
{
    public class ProductosController : Controller
    {
        private ProductoRepositorio repositorio = new ProductoRepositorio();

        // GET: /Productos
        public IActionResult Index()
        {
            var productos = repositorio.ObtenerTodos();
            return View(productos);
        }

        // GET: /Productos/Detalles/5
        public IActionResult Detalles(int id)
        {
            var producto = repositorio.ObtenerPorId(id);

            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Crear
        public IActionResult Crear()
        {
            return View();
        }

        // POST: Crear
        [HttpPost]
        public IActionResult Crear(Producto producto)
        {
            if (ModelState.IsValid)
            {
                repositorio.Agregar(producto);
                return RedirectToAction("Index");
            }

            return View(producto);
        }

        // GET: Editar
        public IActionResult Editar(int id)
        {
            var producto = repositorio.ObtenerPorId(id);

            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Editar
        [HttpPost]
        public IActionResult Editar(Producto producto)
        {
            if (ModelState.IsValid)
            {
                repositorio.Actualizar(producto);
                return RedirectToAction("Index");
            }

            return View(producto);
        }

        // GET: Eliminar
        public IActionResult Eliminar(int id)
        {
            var producto = repositorio.ObtenerPorId(id);

            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Eliminar
        [HttpPost, ActionName("Eliminar")]
        public IActionResult ConfirmarEliminar(int id)
        {
            repositorio.Eliminar(id);
            return RedirectToAction("Index");
        }
    }
}
